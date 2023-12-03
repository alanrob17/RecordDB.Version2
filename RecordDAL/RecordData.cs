// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecordData.cs" company="Software Inc">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Record type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RecordDAL
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Heinemann.Components;
    using RecordDAL.Components;

    /// <summary>
    /// The record data.
    /// </summary>
    public class RecordData
    {
        /// <summary>
        /// Select a single Artist by Id
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public async Task<Record> SelectAsync(int recordId)
        {
            using (var connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                await connection.OpenAsync();

                var sql = "up_RecordSelectById";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RecordId", recordId);

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Record
                            {
                                ArtistName = reader.Field<string>("ArtistName"),
                                ArtistId = reader.Field<int>("ArtistId"),
                                RecordId = reader.Field<int>("RecordId"),
                                Name = reader.Field<string>("Name"),
                                Field = reader.Field<string>("Field"),
                                Recorded = reader.Field<int>("Recorded"),
                                Label = reader.Field<string>("Label"),
                                Pressing = reader.Field<string>("Pressing"),
                                Rating = reader.Field<string>("Rating"),
                                Discs = reader.Field<int>("Discs"),
                                Media = reader.Field<string>("Media"),
                                Bought = DataConvert.ConvertTo<DateTime>(reader["Bought"], default(DateTime)),
                                Cost = DataConvert.ConvertTo<decimal>(reader["Cost"], default(decimal)),
                                CoverName = reader.Field<string>("CoverName"),
                                Review = reader.Field<string>("Review")
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Select a single Artist by Id
        /// </summary>
        /// <param name="artistId">The artist Id.</param>
        public Record Select(int recordId)
        {
            using (var connection = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                connection.Open();

                var sql = "up_RecordSelectById";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RecordId", recordId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Record
                            {
                                ArtistName = reader.Field<string>("ArtistName"),
                                ArtistId = reader.Field<int>("ArtistId"),
                                RecordId = reader.Field<int>("RecordId"),
                                Name = reader.Field<string>("Name"),
                                Field = reader.Field<string>("Field"),
                                Recorded = reader.Field<int>("Recorded"),
                                Label = reader.Field<string>("Label"),
                                Pressing = reader.Field<string>("Pressing"),
                                Rating = reader.Field<string>("Rating"),
                                Discs = reader.Field<int>("Discs"),
                                Media = reader.Field<string>("Media"),
                                Bought = DataConvert.ConvertTo<DateTime>(reader["Bought"], default(DateTime)),
                                Cost = DataConvert.ConvertTo<decimal>(reader["Cost"], default(decimal)),
                                CoverName = reader.Field<string>("CoverName"),
                                Review = reader.Field<string>("Review")
                            };
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Select all Record records.
        /// </summary>
        /// <returns>The <see cref="List"/>list of all record objects.</returns>
        public async Task<List<Record>> SelectAsync()
        {
            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_RecordSelectAll", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new Record
                        {
                            ArtistName = reader.Field<string>("ArtistName"),
                            ArtistId = reader.Field<int>("ArtistId"),
                            RecordId = reader.Field<int>("RecordId"),
                            Name = reader.Field<string>("Name"),
                            Field = reader.Field<string>("Field"),
                            Recorded = reader.Field<int>("Recorded"),
                            Label = reader.Field<string>("Label"),
                            Pressing = reader.Field<string>("Pressing"),
                            Rating = reader.Field<string>("Rating"),
                            Discs = reader.Field<int>("Discs"),
                            Media = reader.Field<string>("Media"),
                            Bought = reader.Field<DateTime?>("Bought").GetValueOrDefault(),
                            Cost = reader.Field<decimal?>("Cost").GetValueOrDefault(),
                            CoverName = reader.Field<string>("CoverName"),
                            Review = reader.Field<string>("Review")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Select all Records from database
        /// filter by show parameter
        /// </summary>
        /// <param name="show">parameter variable</param>
        /// <returns>A list of records.</returns>
        public List<Record> Select(string show)
        {
            if (show == null)
            {
                throw new ArgumentNullException("show");
            }

            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_RecordSelectShowNew", cn) { CommandType = CommandType.StoredProcedure })
            {
                cn.Open();

                cmd.Parameters.AddWithValue("@show", show);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = new Record
                        {
                            ArtistName = reader.Field<string>("ArtistName"),
                            ArtistId = reader.Field<int>("ArtistId"),
                            RecordId = reader.Field<int>("RecordId"),
                            Name = reader.Field<string>("Name"),
                            Field = reader.Field<string>("Field"),
                            Recorded = reader.Field<int>("Recorded"),
                            Label = reader.Field<string>("Label"),
                            Pressing = reader.Field<string>("Pressing"),
                            Rating = reader.Field<string>("Rating"),
                            Discs = reader.Field<int>("Discs"),
                            Media = reader.Field<string>("Media"),
                            Bought = reader.Field<DateTime?>("Bought").GetValueOrDefault(),
                            Cost = reader.Field<decimal?>("Cost").GetValueOrDefault(),
                            CoverName = reader.Field<string>("CoverName"),
                            Review = reader.Field<string>("Review")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Select an artist's records.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <returns>The <see cref="List"/> list of records for a particular artist.</returns>
        public async Task<List<Record>> SelectArtistRecordsAsync(int artistId)
        {
            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_getRecordListAndNone", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                cmd.Parameters.AddWithValue("@artistId", artistId);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new Record
                        {
                            RecordId = reader.Field<int>("RecordId"),
                            Name = reader.Field<string>("Name")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Select records reviews.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public async Task<List<Record>> SelectRecordReviewsAsync()
        {
            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_SelectRecordReviews", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new Record
                        {
                            ArtistName = reader.Field<string>("Name"),
                            Name = reader.Field<string>("Title"),
                            Review = reader.Field<string>("Review")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Select records reviews.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Record> SelectRecordReviews()
        {
            // for ObjectDataSource
            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_SelectRecordReviews", cn) { CommandType = CommandType.StoredProcedure })
            {
                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var record = new Record
                        {
                            ArtistName = reader.Field<string>("Name"),
                            Name = reader.Field<string>("Title"),
                            Review = reader.Field<string>("Review")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Delete an existing Record record.
        /// </summary>
        /// <param name="recordId">The record ID.</param>
        public async Task DeleteAsync(int recordId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_deleteRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@RecordId", recordId);

                await cn.OpenAsync();

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception)
                {
                    recordId = 0;
                }
            }
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        /// <param name="record">The record object.</param>
        /// <returns>The <see cref="int"/> record Id.</returns>
        public async Task<int> InsertAsync(Record record)
        {
            var recordId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_RecordInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistID", record.ArtistId);
                cmd.Parameters.AddWithValue("Name", record.Name);
                cmd.Parameters.AddWithValue("Field", record.Field);
                cmd.Parameters.AddWithValue("Recorded", record.Recorded);
                cmd.Parameters.AddWithValue("Label", record.Label);
                cmd.Parameters.AddWithValue("Pressing", record.Pressing);
                cmd.Parameters.AddWithValue("Rating", record.Rating);
                cmd.Parameters.AddWithValue("Discs", record.Discs);
                cmd.Parameters.AddWithValue("Media", record.Media);
                cmd.Parameters.AddWithValue("Bought", record.Bought);
                cmd.Parameters.AddWithValue("Cost", record.Cost);
                cmd.Parameters.AddWithValue("CoverName", record.CoverName);
                cmd.Parameters.AddWithValue("Review", record.Review);
                cmd.Parameters.AddWithValue("FreeDBID", string.Empty);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    recordId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Insert a new record.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <param name="name">The record title.</param>
        /// <param name="field">The field of music.</param>
        /// <param name="recorded">The year recorded.</param>
        /// <param name="label">The record label.</param>
        /// <param name="pressing">The country of pressing.</param>
        /// <param name="rating">The album rating.</param>
        /// <param name="discs">The number of discs.</param>
        /// <param name="media">The media type.</param>
        /// <param name="bought">The date bought.</param>
        /// <param name="cost">The cost of the record.</param>
        /// <param name="coverName">The image cover name.</param>
        /// <param name="review">The record review.</param>
        /// <returns>the ID of the record</returns>
        public async Task<int> InsertAsync(int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var recordId = -1; // 0 is used for record is already in the db.

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("adm_RecordInsert", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistId", artistId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Field", field);
                cmd.Parameters.AddWithValue("Recorded", recorded);
                cmd.Parameters.AddWithValue("Label", label);
                cmd.Parameters.AddWithValue("Pressing", pressing);
                cmd.Parameters.AddWithValue("Rating", rating);
                cmd.Parameters.AddWithValue("Discs", discs);
                cmd.Parameters.AddWithValue("Media", media);
                cmd.Parameters.AddWithValue("Bought", bought);
                cmd.Parameters.AddWithValue("Cost", cost);
                cmd.Parameters.AddWithValue("CoverName", coverName);
                cmd.Parameters.AddWithValue("Review", review);
                cmd.Parameters.AddWithValue("FreeDBID", string.Empty);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                
                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    recordId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return recordId;
        }

        /// <summary>
        /// Update a Record
        /// </summary>
        /// <param name="recordId">The record id.</param>
        /// <param name="artistId">The artist id.</param>
        /// <param name="name">The record title.</param>
        /// <param name="field">The field of music.</param>
        /// <param name="recorded">The year recorded.</param>
        /// <param name="label">The record label.</param>
        /// <param name="pressing">The country of pressing.</param>
        /// <param name="rating">My rating of this record.</param>
        /// <param name="discs">The number of discs.</param>
        /// <param name="media">The record media - CD, Record, DVD.</param>
        /// <param name="bought">The date bought.</param>
        /// <param name="cost">The cost of this record.</param>
        /// <param name="coverName">The cover name.</param> 
        /// <param name="review">Review of this record.</param>
        /// <returns>The <see cref="int"/>record Id.</returns>
        public async Task<int> UpdateAsync(int recordId, int artistId, string name, string field, int recorded, string label, string pressing, string rating, int discs, string media, DateTime bought, decimal cost, string coverName, string review)
        {
            var newRecordId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", recordId);
                cmd.Parameters.AddWithValue("ArtistId", artistId);
                cmd.Parameters.AddWithValue("Name", name);
                cmd.Parameters.AddWithValue("Field", field);
                cmd.Parameters.AddWithValue("Recorded", recorded);
                cmd.Parameters.AddWithValue("Label", label);
                cmd.Parameters.AddWithValue("Pressing", pressing);
                cmd.Parameters.AddWithValue("Rating", rating);
                cmd.Parameters.AddWithValue("Discs", discs);
                cmd.Parameters.AddWithValue("Media", media);
                cmd.Parameters.AddWithValue("Bought", bought);
                cmd.Parameters.AddWithValue("Cost", cost);
                cmd.Parameters.AddWithValue("CoverName", coverName);
                cmd.Parameters.AddWithValue("Review", review);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    newRecordId = (int)cmd.Parameters["@Result"].Value;
                }
            }

            return newRecordId;
        }

        /// <summary>
        /// Update a record.
        /// </summary>
        /// <param name="record">The record object.</param>
        /// <returns>The <see cref="int"/> record Id.</returns>
        public async Task<int> UpdateAsync(Record record)
        {
            var newRecordId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_UpdateRecord", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("RecordId", record.RecordId);
                cmd.Parameters.AddWithValue("ArtistId", record.ArtistId);
                cmd.Parameters.AddWithValue("Name", record.Name);
                cmd.Parameters.AddWithValue("Field", record.Field);
                cmd.Parameters.AddWithValue("Recorded", record.Recorded);
                cmd.Parameters.AddWithValue("Label", record.Label);
                cmd.Parameters.AddWithValue("Pressing", record.Pressing);
                cmd.Parameters.AddWithValue("Rating", record.Rating);
                cmd.Parameters.AddWithValue("Discs", record.Discs);
                cmd.Parameters.AddWithValue("Media", record.Media);
                cmd.Parameters.AddWithValue("Bought", record.Bought);
                cmd.Parameters.AddWithValue("Cost", record.Cost);
                cmd.Parameters.AddWithValue("CoverName", record.CoverName);
                cmd.Parameters.AddWithValue("Review", record.Review);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (cn)
                {
                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    newRecordId = (int)cmd.Parameters["@Result"].Value;
                }
            }

            return newRecordId;
        }

        /// <summary>
        /// Count number of discs for the browse page.
        /// </summary>
        /// <param name="show">The show querystring value.</param>
        /// <param name="discs">The number of discs.</param>
        /// <returns>The number of Discs.</returns>
        public async Task<string> CountDiscsAsync(string show)
        {
            int discs = 0;

            if (show == null)
            {
                throw new ArgumentNullException("show");
            }
            else
            {
                using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
                {
                    var cmd = new SqlCommand("up_CountDiscs", cn) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("show", show);

                    using (cn)
                    {
                        await cn.OpenAsync();
                        var result = await cmd.ExecuteScalarAsync();
                        discs = (int)result;
                    }
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get Artist's total number of discs.
        /// </summary>
        /// <param name="artistId">The artist id.</param>
        /// <returns>The <see cref="int"/> number of discs.</returns>
        public async Task<string> GetArtistNumberOfRecordsAsync(int artistId)
        {
            var discs = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_GetArtistNumberOfRecords", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@artistId", artistId);

                using (cn)
                {
                    await cn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    discs = (int)result;
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get the total number of all records, DVD's and CD's for the year.
        /// </summary>
        /// <param name="year">
        /// The year.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public async Task<string> GetRecordedYearNumberAsync(int year)
        {
            var discs = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("up_GetRecordedYearNumber", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@year", year);

                using (cn)
                {
                    await cn.OpenAsync();
                    var result = cmd.ExecuteScalar();
                    discs = (int)result;
                }
            }

            return discs.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get a list of records with no reviews.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/> List of records without reviews.</returns>
        public async Task<List<Record>> NoRecordReviewsAsync()
        {
            var records = new List<Record>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("up_NoRecordReviews", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var record = new Record
                        {
                            ArtistName = reader.Field<string>("Name"),
                            Name = reader.Field<string>("Record"),
                            RecordId = reader.Field<int>("RecordId")
                        };

                        records.Add(record);
                    }
                }
            }

            return records;
        }

        /// <summary>
        /// Change object to a short date string.
        /// </summary>
        /// <param name="bought">
        /// The bought.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToShortDate(object bought)
        {
            var shortDate = "unk";

            if (bought != null)
            {
                DateTime dt = Convert.ToDateTime(bought);

                shortDate = Heinemann.Components.Dates.ShortDateString(dt);
            }

            return shortDate;
        }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>A listing of the object properties.</returns>
        public static async Task<string> ToStringAsync(Record record)
        {
            var artistData = new ArtistData();
            var artist = await artistData.SelectAsync(record.ArtistId);
            var str = new StringBuilder();

            str.Append("<strong>RecordId: </strong>" + record.RecordId + "<br/>");
            str.Append("<strong>ArtistId: </strong>" + record.ArtistId + "<br/>");
            str.Append("<strong>ArtistName: </strong>" + artist.Name + "<br/>");
            str.Append("<strong>Name: </strong>" + record.Name + "<br/>");
            str.Append("<strong>Field: </strong>" + record.Field + "<br/>");
            str.Append("<strong>Recorded: </strong>" + record.Recorded + "<br/>");
            str.Append("<strong>Label: </strong>" + record.Label + "<br/>");
            str.Append("<strong>Pressing: </strong>" + record.Pressing + "<br/>");
            str.Append("<strong>Rating: </strong>" + record.Rating + "<br/>");
            str.Append("<strong>Discs: </strong>" + record.Discs + "<br/>");
            str.Append("<strong>Media: </strong>" + record.Media + "<br/>");

            if (record.Bought > DateTime.MinValue)
            {
                str.Append("<strong>Bought: </strong>" + record.Bought.ToShortDateString() + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.Cost.ToString(CultureInfo.InvariantCulture)))
            {
                str.Append("<strong>Cost: </strong>" + record.Cost + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.CoverName))
            {
                str.Append("<strong>CoverName: </strong>" + record.CoverName + "<br/>");
            }

            if (!string.IsNullOrEmpty(record.Review))
            {
                str.Append("<strong>Review: </strong>" + record.Review + "<br/>");
            }

            return str.ToString();
        }

        /// <summary>
        /// Get total cost for each artist.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>list of artists and their total costs.</returns>
        public async Task<List<Total>> GetTotalCostsAsync()
        {
            var totals = new List<Total>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("sp_getTotalsForEachArtist", cn) { CommandType = CommandType.StoredProcedure })
            {
                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var total = new Total()
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            Name = reader.Field<string>("Name"),
                            TotalDiscs = reader.Field<int>("TotalDiscs"),
                            TotalCost = reader.Field<decimal>("TotalCost")
                        };


                        totals.Add(total);
                    }
                }
            }

            return totals;
        }

        /// <summary>
        /// Get total cost for each artist.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>list of artists and their total costs.</returns>
        public IEnumerable<Total> GetTotalCosts()
        {
            var totals = new List<Total>();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            using (var cmd = new SqlCommand("sp_getTotalsForEachArtist", cn) { CommandType = CommandType.StoredProcedure })
            {
                cn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var total = new Total()
                        {
                            ArtistId = reader.Field<int>("ArtistId"),
                            Name = reader.Field<string>("Name"),
                            TotalDiscs = reader.Field<int>("TotalDiscs"),
                            TotalCost = reader.Field<decimal>("TotalCost")
                        };


                        totals.Add(total);
                    }
                }
            }

            return totals;
        }
    }
}
