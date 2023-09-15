using SIGL_Cadastru.Repo.Models;
using System;
using System.Reflection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SIGL_Cadastru.Repo.DataBase.CustomConverters;

public class CustomPortofoliuConverter : JsonConverter<Portofoliu>
{

    public CustomPortofoliuConverter()
    {

    }
    public override void WriteJson(JsonWriter writer, Portofoliu? portofoliu, JsonSerializer serializer)
    {
        JObject jo = new();

        jo[nameof(portofoliu.Lucrari)] = JToken.FromObject(portofoliu.Lucrari, serializer);
        jo[nameof(portofoliu.Documente)] = JToken.FromObject(portofoliu.Documente, serializer);


        jo.WriteTo(writer);
    }
    public override Portofoliu? ReadJson(JsonReader reader, Type objectType, Portofoliu? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jo = JObject.Load(reader);

        return jo.ToObject<Portofoliu>();
    }

}
