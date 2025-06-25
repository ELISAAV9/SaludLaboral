using Newtonsoft.Json;

namespace Final.Datos
{
    public class MapperEntity
    {
        public Out ToEntity<Out>(Object input)
        {
            string output = JsonConvert.SerializeObject(input,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                        NullValueHandling = NullValueHandling.Ignore
                    }
                );

            return JsonConvert.DeserializeObject<Out>(output);
        }
    }
}
