using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MetalGenerator {
    public partial class index : System.Web.UI.Page {

        String generatedName = "";
        String albumName = "";
        bool searchResult = false;

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void Page_Init(object sender, EventArgs e) {
            if (Request.RawUrl != "/")
                Response.Redirect("/");
        }

        protected void InsertName(object sender, EventArgs e) {
            GenerateName();
            bandname.InnerHtml = generatedName;
            album.InnerHtml = albumName;
            spotify1.InnerHtml = SpotifyArtist();
            spotify2.InnerHtml = SpotifyAlbum();
            spotify3.InnerHtml = SpotifyTrack();
            genre.InnerHtml = GenerateGenre();

            title.InnerHtml = "Fetal Punch - " + generatedName;       
        }

        void GenerateName() {
            Random rnd = new Random();

            List<String> nouns = new List<String>() { "goat", "wizard", "whore", "spine", "flesh", "snake", "death", "hell", "blood", "flame", "hate", "demon", "brain", "beast", "war", "zombie", "heart", "murder", "hate", "punch", "kick", "limb", "maggot", "curse", "dragon", "fetus", "plague", "stone", "cranium", "ritual", "satan", "devil", "cannibal", "corpse" };
            List<String> verbs = new List<String>() { "ripping", "cutting", "eviscerating", "necrotizing", "rotting", "festering", "dying", "pulsing" };
            List<String> adjectives = new List<String>() { "dark", "black", "fetal", "broken", "buried", "cursed", "consumed", "rotted", "desolate", "forced", "dead", "engorged", "putrid", "aborted", "feral", "undead" };

            var nameType = rnd.Next(0,3);

            //noun noun
            if (nameType == 0) {
                String word1 = nouns[rnd.Next(0, nouns.Count)];
                String word2 = "";
                do {
                    word2 = nouns[rnd.Next(0, nouns.Count)];
                } while (word2 == word1);
                                
                generatedName =  word1 + " " + word2;
            }

            //verb noun
            else if (nameType == 1) {
                String word1 = verbs[rnd.Next(0, verbs.Count)];
                String word2 = nouns[rnd.Next(0, nouns.Count)];
                generatedName = word1 + " " + word2;
            }

            //adjective noun
            else if (nameType == 2) {
                String word1 = adjectives[rnd.Next(0, adjectives.Count)];
                String word2 = nouns[rnd.Next(0, nouns.Count)];
                generatedName = word1 + " " + word2;
            }

            
            String albumword1 = verbs[rnd.Next(0, verbs.Count)];
            String albumword2 = adjectives[rnd.Next(0, adjectives.Count)];
            String albumword3 = nouns[rnd.Next(0, nouns.Count)];
            albumName = albumword1 + " " + albumword2 + " " + albumword3;               
        }

        String GenerateGenre() {
            try {
                Random rnd = new Random();

                List<String> genres = new List<String>() { "black", "doom", "death" };
                List<String> descriptors = new List<String>() { "melodic", "brutal", "technical" };

                String genre = "";

                if(rnd.Next(0,2) != 0) {
                    genre = genre + descriptors[rnd.Next(0, descriptors.Count)] + " ";
                }
                
                genre = genre + genres[rnd.Next(0, genres.Count)] + " metal";

                if(rnd.Next(0,8) == 0) {
                    genre = genre + "core";
                }

                return genre;
                
            } catch (Exception ex) {
                return "I BROKE";
            }
        }

        String SpotifyArtist() {
            WebRequest request = WebRequest.Create("https://api.spotify.com/v1/search?q=" + generatedName.Replace(' ', '+') + "&type=artist&market=US&limit=10");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonResponse = reader.ReadToEnd();
            JObject spotifyResponse = JObject.Parse(jsonResponse);
            if(((JArray)spotifyResponse["artists"]["items"]).Count > 0) {            
                    searchResult = true;            
                return "<iframe src=\"https://embed.spotify.com/?uri=spotify:artist:" + spotifyResponse["artists"]["items"].First()["id"] + "\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\"></iframe>";
            } else {
                return "No artist results for " + generatedName;
            }                       
        }

        String SpotifyAlbum() {
            WebRequest request = WebRequest.Create("https://api.spotify.com/v1/search?q=" + generatedName.Replace(' ', '+') + "&type=album&market=US&limit=10");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonResponse = reader.ReadToEnd();
            JObject spotifyResponse = JObject.Parse(jsonResponse);
            if (((JArray)spotifyResponse["albums"]["items"]).Count > 0) {
                searchResult = true;
                return "<iframe src=\"https://embed.spotify.com/?uri=spotify:album:" + spotifyResponse["albums"]["items"].First()["id"] + "\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\"></iframe>";
            } else {
                return "No album results for " + generatedName;
            }
        }

        String SpotifyTrack() {
            WebRequest request = WebRequest.Create("https://api.spotify.com/v1/search?q=" + generatedName.Replace(' ', '+') + "&type=track&market=US&limit=10");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string jsonResponse = reader.ReadToEnd();
            JObject spotifyResponse = JObject.Parse(jsonResponse);
            if (((JArray)spotifyResponse["tracks"]["items"]).Count > 0) {
                searchResult = true;
                return "<iframe src=\"https://embed.spotify.com/?uri=spotify:track:" + spotifyResponse["tracks"]["items"].First()["id"] + "\" width=\"300\" height=\"380\" frameborder=\"0\" allowtransparency=\"true\"></iframe>";
            } else {
                return "No track results for " + generatedName;
            }
        }

    }
  
}