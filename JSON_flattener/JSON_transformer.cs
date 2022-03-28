using Newtonsoft.Json.Linq;

namespace JSON_flattener
{
    public static class JSON_transformer
    {
        public static Dictionary<string, string> GetPropertiesFromJson(string json_file)
        {
            var jobject = new JObject();
            string json_message;

            try
            {
                json_message = File.ReadAllText(json_file);
            }
            catch
            {
                throw new FileNotFoundException("File not found. Check the filename");
            }

            if (json_message.Length == 0)
                throw new ArgumentOutOfRangeException("json_message", json_message, "Json file is empty");

            try
            {
                jobject = JObject.Parse(json_message); //parse to JObject the JSON string
            }
            catch 
            {
                throw new Exception("Couldn't parse object, format of JSON is wrong");
            }


            return jobject.Descendants() //get the children
                                        //check if it has or not elements
                                        //using Any instead of Count to save on performance
                .Where(j => !j.Children().Any())
                .Aggregate(
                    new Dictionary<string, string>(),
                    (props, jtoken) =>   //(result,item) where jtoken is the value in the dictionary (type JToken, basically can be any type)
                    {
                        props.Add(jtoken.Path, jtoken.ToString()); //jtoken.Path() - the key
                        return props;
                    });
        }
    }
}
