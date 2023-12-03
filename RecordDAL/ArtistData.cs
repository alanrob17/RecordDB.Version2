// --------------------------------------------------------------------------------------------------------------------- 
// <copyright file="ArtistData.cs" company="Software Inc">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Artist Data type.
// </summary>
// ---------------------------------------------------------------------------------------------------------------------
namespace RecordDAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RecordDAL.Components;

    public class ArtistData
    {
        #region " Methods "        

        // used for ObjectDataSource
        public List<Artist> GetArtists()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_ArtistSelectAll", cn) { CommandType = CommandType.StoredProcedure })
            {
                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var artist = new Artist
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            FirstName = reader.Field<string>("FirstName"),
                            LastName = reader.Field<string>("LastName"),
                            Name = reader.Field<string>("Name"),
                            Biography = reader.Field<string>("Biography")
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        public static async Task<List<Artist>> GetArtistsAsync()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_ArtistSelectAll", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var artist = new Artist
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            FirstName = reader.Field<string>("FirstName"),
                            LastName = reader.Field<string>("LastName"),
                            Name = reader.Field<string>("Name"),
                            Biography = reader.Field<string>("Biography")
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        public async Task<List<Artist>> GetArtistListAsync()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_getArtistListandNone", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var artist = new Artist
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            Name = reader.Field<string>("Name")
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        /// <summary>
        /// Select all Artist records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of artists.</returns>
        public async Task<List<Artist>> SelectAsync()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_ArtistSelectAll", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var artist = new Artist
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            FirstName = reader.Field<string>("FirstName"),
                            LastName = reader.Field<string>("LastName"),
                            Name = reader.Field<string>("Name"),
                            Biography = reader.Field<string>("Biography")
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        /// <summary>
        /// Select a single Artist by Id
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public async Task<Artist> SelectAsync(int artistId)
        {
            using (var connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                await connection.OpenAsync();

                var sql = "up_ArtistSelectById";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArtistId", artistId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Artist
                            {
                                ArtistId = reader.Field<int>("ArtistId"),
                                FirstName = reader.Field<string>("FirstName"),
                                LastName = reader.Field<string>("LastName"),
                                Name = reader.Field<string>("Name"),
                                Biography = reader.Field<string>("Biography")
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Select all Artist records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of artists.</returns>
        public async Task<List<Artist>> GetArtistNamesAsync()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_ArtistSelectAll", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var artist = new Artist
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            FirstName = reader.Field<string>("FirstName"),
                            LastName = reader.Field<string>("LastName"),
                            Name = reader.Field<string>("Name"),
                            Biography = reader.Field<string>("Biography")
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        /// <summary>
        /// Select all Artists from database
        /// where a biography doesn't exist
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>list of artists with no biography.</returns>
        public async Task<List<Artist>> SelectArtistWithNoBioAsync()
        {
            var artists = new List<Artist>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_selectArtistsWithNoBio", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var artist = new Artist
                        {

                            ArtistId = reader.Field<int>("ArtistId"),
                            Name = reader.Field<string>("Name"),
                        };

                        artists.Add(artist);
                    }
                }
            }

            return artists;
        }

        /// <summary>
        /// Create a new Artist
        /// </summary>
        /// <param name="artist">The artist entity.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public async Task<int> InsertAsync(Artist artist)
        {
            var artistId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_ArtistInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("ArtistId", artist.ArtistId);
                cmd.Parameters.AddWithValue("FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("LastName", artist.LastName);
                cmd.Parameters.AddWithValue("Biography", artist.Biography);
                var parArtistId = new SqlParameter("@artistId", SqlDbType.Int, 4)
                                      {
                                          Direction = ParameterDirection.ReturnValue
                                      };
                cmd.Parameters.Add(parArtistId);
                
                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    artistId = int.Parse(parArtistId.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Create a new Artist
        /// </summary>
        /// <param name="firstName">The first Name.</param>
        /// <param name="lastName">The last Name.</param>
        /// <param name="biography">The biography.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public async Task<int> InsertAsync(int artistId, string firstName, string lastName, string biography)
        {
            artistId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_ArtistInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("ArtistId", artistId);
                cmd.Parameters.AddWithValue("FirstName", firstName);
                cmd.Parameters.AddWithValue("LastName", lastName);
                cmd.Parameters.AddWithValue("Biography", biography);
                var parResult = new SqlParameter("@Result", SqlDbType.Int, 4)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parResult);

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    var result = parResult.Value.ToString();
                    if (int.TryParse(result, out var parsedArtistId))
                    {
                        artistId = parsedArtistId;
                    }
                    else
                    {
                        // Handle the case where the conversion fails, log an error, throw an exception, etc.
                    }
                }
            }

            return artistId;
        }

        /// <summary>
        /// Update the current artist record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="name">The full name.</param>
        /// <param name="biography">The artist biography.</param>
        /// <returns>The <see cref="int"/>artist Id.</returns>
        public async Task<int> UpdateArtistAsync(int artistId, string firstName, string lastName, string name, string biography)
        {
            var newArtistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Biography", biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                                            {
                                                Direction =
                                                    ParameterDirection
                                                    .ReturnValue
                                            };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    newArtistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return newArtistId;
        }

        /// <summary>
        /// Update an artist record.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public async Task<int> UpdateArtistAsync(Artist artist)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistID", artist.ArtistId);
                cmd.Parameters.AddWithValue("@FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("@LastName", artist.LastName);
                cmd.Parameters.AddWithValue("@Name", artist.Name);
                cmd.Parameters.AddWithValue("@Biography", artist.Biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    artistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Update the current artist record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="name">The full name.</param>
        /// <param name="biography">The artist biography.</param>
        /// <returns>The <see cref="int"/>artist Id.</returns>
        public async Task<int> UpdateAsync(int artistId, string firstName, string lastName, string name, string biography)
        {
            var newArtistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Biography", biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    newArtistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return newArtistId;
        }

        /// <summary>
        /// Update an artist record.
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="int"/>Artist Id.</returns>
        public async Task<int> UpdateAsync(Artist artist)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistID", artist.ArtistId);
                cmd.Parameters.AddWithValue("@FirstName", artist.FirstName);
                cmd.Parameters.AddWithValue("@LastName", artist.LastName);
                cmd.Parameters.AddWithValue("@Name", artist.Name);
                cmd.Parameters.AddWithValue("@Biography", artist.Biography);
                var artistIdParameter = new SqlParameter("@artistId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(artistIdParameter);

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    artistId = int.Parse(artistIdParameter.Value.ToString());
                }
            }

            return artistId;
        }

        /// <summary>
        /// Get the artist id.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>The <see cref="int"/> artist Id.</returns>
        public async Task<int> GetArtistIdAsync(string firstName, string lastName)
        {
            var artistId = -1; // 0 is used for a record that is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getArtistIdByName", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                var parArtistId = new SqlParameter("@artistId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parArtistId);

                await cn.OpenAsync();

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    artistId = (int)parArtistId.Value;
                }
                catch (Exception)
                {
                    artistId = 0;
                }
            }

            return artistId;
        }

        /// <summary>
        /// Get the artist id.
        /// </summary>
        /// <param name="recordId">The record Id.</param>
        /// <returns>The <see cref="int"/> artist Id.</returns>
        public async Task<int> GetArtistIdAsync(int recordId)
        {
            var artistId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getArtistIdFromRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@RecordId", recordId);
                var parArtistId = new SqlParameter("@artistId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(parArtistId);

                await cn.OpenAsync();

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    artistId = (int)parArtistId.Value;
                }
                catch (Exception)
                {
                    artistId = 0;
                }
            }

            return artistId;
        }

        /// <summary>
        /// Delete an existing Artist record.
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public async Task DeleteAsync(int artistId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_deleteArtist", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ArtistId", artistId);

                await cn.OpenAsync();

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    artistId = 0;
                }
            }
        }

        /// <summary>
        /// Get a biography.
        /// </summary>
        /// <param name="recordId">The record Id.</param>
        /// <returns>
        /// The <see cref="object"/>biography.</returns>
        public async Task<string> GetBiographyAsync(int recordId)
        {
            var biography = string.Empty;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getBiography", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("recordId", recordId);

                await cn.OpenAsync();

                biography = (string)await cmd.ExecuteScalarAsync();
            }

            return biography;
        }

        /// <summary>
        /// Get a biography.
        /// </summary>
        /// <param name="recordId">The record Id.</param>
        /// <returns>
        /// The <see cref="object"/>biography.</returns>
        public string GetBiography(int recordId)
        {
            var biography = string.Empty;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_getBiography", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("recordId", recordId);

                cn.Open();

                biography = (string)cmd.ExecuteScalar();
            }

            return biography;
        }

        /// <summary>
        /// ToString method shows an instances properties
        /// </summary>
        /// <param name="artist">The artist.</param>
        /// <returns>The <see cref="string"/> artist record as a string.</returns>
        public static string ToString(Artist artist)
        {
            var artistDetails = new StringBuilder();

            artistDetails.Append("<strong>ArtistId: </strong>" + artist.ArtistId + "<br/>");

            if (!string.IsNullOrEmpty(artist.FirstName))
            {
                artistDetails.Append("<strong>First Name: </strong>" + artist.FirstName + "<br/>");
            }

            artistDetails.Append("<strong>Last Name: </strong>" + artist.LastName + "<br/>");

            if (!string.IsNullOrEmpty(artist.Name))
            {
                artistDetails.Append("<strong>Name: </strong>" + artist.Name + "<br/>");
            }

            if (!string.IsNullOrEmpty(artist.Biography))
            {
                artistDetails.Append("<strong>Biography: </strong>" + artist.Biography + "<br/>");
            }

            return artistDetails.ToString();
        }

        /// <summary>
        /// Get artist object by record id.
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <returns>The <see cref="Artist"/> artist object.</returns>
        public async Task<Artist> GetArtistByRecordIdAsync(int recordId)
        {
            using (var connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                await connection.OpenAsync();

                var sql = "up_ArtistSelectByRecordId";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RecordId", recordId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Artist
                            {
                                ArtistId = reader.Field<int>("ArtistId"),
                                FirstName = reader.Field<string>("FirstName"),
                                LastName = reader.Field<string>("LastName"),
                                Name = reader.Field<string>("Name"),
                                Biography = reader.Field<string>("Biography")
                            };
                        }
                    }
                }
            }

            return null;
        }


        #endregion
    }
}
