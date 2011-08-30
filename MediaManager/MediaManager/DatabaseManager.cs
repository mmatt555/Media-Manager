using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MediaManager
{
    public static class DatabaseManager
    {
        private static SQLiteConnection _Conn;  //Global Connection to database
        private static SQLiteCommand _cmdInsert;
        private static SQLiteCommand _cmdUpdate;
		private static SQLiteCommand _cmdDelete;
        
        public static void InitializeManager()
        {
            _Conn = new SQLiteConnection();
            if (File.Exists("Storage.mmd"))  //If the Database already exists, open a connection
            {
                _Conn.ConnectionString = "Data Source=Storage.mmd;Version=3;New=False;Compress=True;";
                _Conn.Open();
				
            }

            else //If we need a new Database
			#region Create New Database
            {
                System.Windows.MessageBox.Show  //Inform the User
                    (
                    "Media Manager has detected that this is your\n" +
                    "first time opening Media Manager, and is now \n" +
                    "constructing a new Database.",
                    "Making Media Manager!"
                    );

                _Conn.ConnectionString = "Data Source=Storage.mmd;Version=3;Compress=True;";  //Set Connection String
                _Conn.Open(); //Open Connection (creates new file)

                SQLiteCommand sqCommand = new SQLiteCommand(); //Prepare command
                sqCommand.Connection = _Conn;  //Set connection of SQL command
                
                //The following sets the SQL needed to create the main table
                sqCommand.CommandText =
                    "CREATE TABLE [tbl_Maintable] (" +
                    "[film_ID] INTEGER  PRIMARY KEY AUTOINCREMENT NOT NULL," +    //0
                    "[film_Name] TEXT  NOT NULL," +                               //1
                    "[film_Image] BLOB  NOT NULL," +                              //2
                    "[film_Plot] TEXT  NOT NULL," +                               //3
                    "[film_Rating] FLOAT  NOT NULL," +                            //4
                    "[film_Genres] TEXT  NOT NULL," +                             //5
                    "[film_ReleaseYear] INTEGER  NOT NULL," +                     //6
                    "[film_Directory] TEXT NOT NULL" +                            //7
                    ")";
                sqCommand.ExecuteNonQuery(); //Execute the command
				
                Directory.CreateDirectory(Environment.CurrentDirectory +@"\Movies");
            }
			#endregion

            #region SQL Statement for Inserting New Film
            _cmdInsert = new SQLiteCommand("INSERT INTO [tbl_Maintable] (film_Name,film_Image,film_Plot,film_Rating,film_Genres,film_ReleaseYear, film_Directory) VALUES (@Name,@Image,@Plot,@Rating,@Genres,@ReleaseYear, @Directory)", _Conn);
            _cmdInsert.Parameters.Add("@Name", DbType.String);
            _cmdInsert.Parameters.Add("@Image", DbType.Binary);
            _cmdInsert.Parameters.Add("@Plot", DbType.String);
            _cmdInsert.Parameters.Add("@Rating", DbType.Double);
            _cmdInsert.Parameters.Add("@Genres", DbType.String);
            _cmdInsert.Parameters.Add("@ReleaseYear", DbType.Int32);
            _cmdInsert.Parameters.Add("@Directory", DbType.String);
            #endregion

            #region SQL Statement for Updating Film
            _cmdUpdate = new SQLiteCommand(
                "UPDATE [tbl_Maintable] " +
                "SET film_Name = @Name, film_Image = @Image, film_Plot = @Plot, film_Rating = @Rating, film_Genres = @Genres, film_ReleaseYear = @ReleaseYear " +
                "WHERE film_ID = @ID"
                ,_Conn
                );
            _cmdUpdate.Parameters.Add("@Name", DbType.String);
            _cmdUpdate.Parameters.Add("@Image", DbType.Binary);
            _cmdUpdate.Parameters.Add("@Plot", DbType.String);
            _cmdUpdate.Parameters.Add("@Rating", DbType.Double);
            _cmdUpdate.Parameters.Add("@Genres", DbType.String);
            _cmdUpdate.Parameters.Add("@ReleaseYear", DbType.Int32);
            _cmdUpdate.Parameters.Add("@ID", DbType.Int16);
            #endregion

            #region SQL Statement for Deleting Film Records
            _cmdDelete = new SQLiteCommand("DELETE FROM [tbl_Maintable] WHERE film_ID = @ID");
			_cmdDelete.Parameters.Add("@ID", DbType.Int16);
            #endregion
        }

        public static DataSet GetDataSet(string CommandText)
        {
            try
            {
                DataSet dsDataSet = new DataSet();
                SQLiteDataAdapter sqdaDataAdapter = new SQLiteDataAdapter(CommandText, _Conn);
                sqdaDataAdapter.Fill(dsDataSet);
                return dsDataSet;
            }

            catch (Exception excep)
            {
                System.Windows.MessageBox.Show("Database Data Request Failed: \n" + "SQL Statement: " + CommandText + "\nError Message: " + excep.Message, "An Error Has Occurred");
                return null;
            }
        }

        public static List<Film> GetFilmList(string CommandText)
        {
            try
            {
                DataSet dsDataSet = new DataSet();
                SQLiteDataAdapter sqdaDataAdapter = new SQLiteDataAdapter(CommandText, _Conn);
                sqdaDataAdapter.Fill(dsDataSet);
                DataTable dtDataTable = dsDataSet.Tables[0];
                List<Film> FilmList = new List<Film>();

                for (int index = 0; index < dtDataTable.Rows.Count; index++)
                {
                    Film fTemp = new Film();
                    fTemp.ID = Convert.ToInt32(dtDataTable.Rows[index].ItemArray[0]);

                    fTemp.Name = (string)dtDataTable.Rows[index].ItemArray[1];

                    fTemp.Plot = (string)dtDataTable.Rows[index].ItemArray[3];

                    fTemp.Rating = Convert.ToString(dtDataTable.Rows[index].ItemArray[4]);
                    fTemp.Genres = (string)dtDataTable.Rows[index].ItemArray[5];
                    fTemp.ReleaseYear = Convert.ToInt32(dtDataTable.Rows[index].ItemArray[6]);
                    fTemp.Directory = (string)dtDataTable.Rows[index].ItemArray[7];

                    BitmapImage biImage = new BitmapImage();
                    MemoryStream ms = new MemoryStream((byte[])dtDataTable.Rows[index].ItemArray[2]);
                    biImage.BeginInit();
                    biImage.StreamSource = ms;
                    biImage.EndInit();
                    fTemp.Image = biImage;
                   

                    FilmList.Add(fTemp);
                }

                return FilmList;
                
            }

            catch (Exception excep)
            {
                System.Windows.MessageBox.Show("Database Data Request Failed: \n" + "SQL Statement: " + CommandText + "\nError Message: " + excep.Message, "An Error Has Occurred");
                return null;
            }

        }

        public static void AddFilm(Film fFilm)
        {
            try
            {
                _cmdInsert.Parameters[0].Value = fFilm.Name;

                Stream ms = fFilm.Image.StreamSource;
                byte[] Image;
                ms.Seek(0, 0);
                BinaryReader br = new BinaryReader(ms);
                Image = br.ReadBytes(Convert.ToInt32(ms.Length));

                _cmdInsert.Parameters[1].Value = Image;
                _cmdInsert.Parameters[2].Value = fFilm.Plot;
                _cmdInsert.Parameters[3].Value = fFilm.Rating;
                _cmdInsert.Parameters[4].Value = fFilm.Genres;
                _cmdInsert.Parameters[5].Value = fFilm.ReleaseYear;
                _cmdInsert.Parameters[6].Value = fFilm.Directory;
                _cmdInsert.ExecuteNonQuery();
                System.Windows.MessageBox.Show("Film added successfully");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }


        }

        public static string MakeDirectorySafe(string Directory)
        {
            string strReturn;
            strReturn = Directory.Replace(">", "_");
            strReturn = strReturn.Replace("<", "_");
            strReturn = strReturn.Replace(":", "_");
            strReturn = strReturn.Replace("|", "_");
            strReturn = strReturn.Replace(@"\", "_");
            strReturn = strReturn.Replace(@"/", "_");
            strReturn = strReturn.Replace("?", "_");
            strReturn = strReturn.Replace("*", "_");
            strReturn = strReturn.Replace('"', '_');



            return strReturn;
        }

        public static void UpdateFilm(Film fFilm)
        {
            try
            {

                _cmdUpdate.Parameters[0].Value = fFilm.Name;

                Stream ms = fFilm.Image.StreamSource;
                byte[] Image;
                ms.Seek(0, 0);
                BinaryReader br = new BinaryReader(ms);
                Image = br.ReadBytes(Convert.ToInt32(ms.Length));
                _cmdUpdate.Parameters[1].Value = Image;


                _cmdUpdate.Parameters[2].Value = fFilm.Plot;
                _cmdUpdate.Parameters[3].Value = fFilm.Rating;
                _cmdUpdate.Parameters[4].Value = fFilm.Genres;
                _cmdUpdate.Parameters[5].Value = fFilm.ReleaseYear;
                System.Windows.MessageBox.Show(fFilm.ID.ToString());
                _cmdUpdate.Parameters[6].Value = fFilm.ID;
                _cmdUpdate.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
		
		public static void DeleteFilm(Film fFilm)
		{
			_cmdDelete.Parameters[0].Value = fFilm.ID;
			_cmdDelete.ExecuteNonQuery();
			
		}
		
		

    }
}
