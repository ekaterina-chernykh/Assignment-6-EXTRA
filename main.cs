// Created by: Ekaterina
// Created on: Jan 2023
//
// This program shows a random fact about dogs

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://dogapi.dog/api/v1/facts"
        );
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        Console.WriteLine("");
        JsonNode dogsNode = JsonNode.Parse(response)!;
        JsonNode factsNode = dogsNode!["facts"]!;
        string fact = factsNode[0].ToString();
        Console.WriteLine(fact);
        Console.WriteLine("\nDone.");
    }
}