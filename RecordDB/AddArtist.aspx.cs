using RecordDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecordDB
{
    public partial class AddArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dtnow = DateTime.Now;
            dateLabel.Text = dtnow.ToLongDateString();
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(SubmitAsync));
        }

        private async Task SubmitAsync()
        {
            var artistData = new ArtistData();
            var artist = new Artist
            {
                ArtistId = 0,
                FirstName = this.firstNameTextBox.Text,
                LastName = this.lastNameTextBox.Text,
                Biography = this.biographyTextBox.Text
            };

            var artistId = await artistData.InsertAsync(artist.ArtistId, artist.FirstName, artist.LastName, artist.Biography);

            divMessageArea.Visible = true;

            // Show the new artist id
            if (artistId == 0)
            {
                messageLabel.Text = "ERROR: Artist was not added! " + artistId;
            }
            else
            {
                messageLabel.Text = "Artist Id: " + artistId + "<br/>";
                messageLabel.Text += "<strong>" + artist.Biography + "</strong>";
            }
        }

        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }
    }
}