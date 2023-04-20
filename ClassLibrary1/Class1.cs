using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class PersonConverter : JsonConverter<Person>
    {
        public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var personName = "Undefined";
            var personAge = 0;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName?.ToLower())
                    {
                        // если свойство age и оно содержит число
                        case "age" when reader.TokenType == JsonTokenType.Number:
                            personAge = reader.GetInt32();  // считываем число из json
                            break;
                        // если свойство age и оно содержит строку
                        case "age" when reader.TokenType == JsonTokenType.String:
                            string? stringValue = reader.GetString();
                            // пытаемся конвертировать строку в число
                            if (int.TryParse(stringValue, out int value))
                            {
                                personAge = value;
                            }
                            break;
                        case "name":    // если свойство Name/name
                            string? name = reader.GetString();
                            if (name != null)
                                personName = name;
                            break;
                    }
                }
            }
            return new Person(personName, personAge);
        }
    }
