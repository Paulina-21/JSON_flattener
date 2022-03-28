// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using JSON_flattener;

var d = JSON_transformer.GetPropertiesFromJson("test.json");

Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(d, new JsonSerializerOptions { WriteIndented = true }));
