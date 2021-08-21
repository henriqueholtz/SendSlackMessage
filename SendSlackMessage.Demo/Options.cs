using SendSlackMessage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSlackMessage.Demo
{
    public static class Options
    {
        public static Message GetOptionByCode(int code)
        {
            switch (code)
            {
                case 1:
                    return new Message("override after", "SendSlackMessage - 1", Emoji.Coffee, "", "This is a first option predefined.");
                case 2:
                    return new Message("override after", "You are using SendSlackMessages by Henrique Holtz.", new List<Attachment>
                    {
                        new Attachment("This is the first Line (Attachment)"),
                        new Attachment("This is the second Line (Attachment)", "good", new List<Field>()
                        )
                    });
                case 3:
                    return new Message("override after", "You are using SendSlackMessages by Henrique Holtz.", new List<Attachment>
                    {
                        new Attachment("This is the first Line (Attachment) - without field"),
                        new Attachment("This is the second Line (Attachment) with field", "good", new List<Field>()
                        {
                            new Field(Emoji.HeavyCheckMark + " Success", "Value (Field)")
                        })
                    });
                default:
                    return new Message("override after", "SendSlackMessage - Default", Emoji.Bomb, "", "This is a default option predefined.");
            }
        }
    }
}
