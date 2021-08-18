using SendSlackMessage.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SendSlackMessage.Entities
{
    public class Attachment
    {
        [JsonPropertyName("fallback")]
        public string Fallback { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("pretext")]
        public string Pretext { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; } = new List<Field>();
        /// <summary>
        ///     Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }

        [JsonPropertyName("author_link")]
        public string AuthorLink { get; set; }

        [JsonPropertyName("author_icon")]
        public string AuthorIcon { get; set; }

        [JsonPropertyName("title_link")]
        public string TitleLink { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }

        [JsonPropertyName("footer")]
        public string Footer { get; set; }

        [JsonPropertyName("footer_icon")]
        public string FooterIcon { get; set; }

        [JsonPropertyName("ts")]
        public string FooterTimeStamp { get; set; }


        /* Constructors */ 
        public Attachment() {  }
        public Attachment(string text)
        {
            Text = text;
        }
        public Attachment(string text, string color)
        {
            Text = text;
            Color = color;
        }


        /* Methods */
        public Attachment AddField(string title, string value, bool _short = false)
        {
            Fields.Add(new Field
            {
                Title = title,
                Value = value,
                Short = _short
            });

            return this;
        }
        public Attachment SetFooter(string footerText, string footerIcon/*, DateTime footerTimeStamp*/)
        {
            Footer = footerText;
            FooterIcon = footerIcon;
            //lack set FooterTimeStamp
            return this;
        }
        public Attachment SetAuthor(string authorName, string authorLink = null, string authorIcon = null)
        {
            AuthorName = authorName;
            AuthorLink = authorLink;
            AuthorIcon = authorIcon;
            return this;
        }
        public Attachment SetColor(EnumColor color)
        {
            switch(color)
            {
                case EnumColor.Green:
                    Color = "good";
                    break;
                case EnumColor.Orange:
                    Color = "warning";
                    break;
                case EnumColor.Red:
                    Color = "danger";
                    break;
                default:
                    Color = null;
                    break;
            }
            return this;
        }
        public Attachment SetColor(string hexCodeColor)
        {
            Color = hexCodeColor;
            return this;
        }
        public Attachment setText(string text)
        {
            Text = text;
            return this;
        }
    }
}
