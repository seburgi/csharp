using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Logistics.Hackathon.Model;

public static class HackathonMap
{

    // Lazy field to hold the parsed result
    private static readonly Lazy<List<Location>> _locations = new Lazy<List<Location>>(ParseLocationsFromJson);

    // Public property to access the parsed locations
    public static List<Location> Locations => _locations.Value;

    private static List<Location> ParseLocationsFromJson()
    {
        // Get the current assembly path
        var assembly = Assembly.GetExecutingAssembly();
        string resourcePath = Path.Combine(AppContext.BaseDirectory, "Resources", "map.json");

        // Check if the file exists
        if (!File.Exists(resourcePath))
        {
            throw new FileNotFoundException("The map.json file was not found in the Resources folder.");
        }

        // Read the JSON file content
        string jsonContent = File.ReadAllText(resourcePath);

        // Parse the JSON content into a list of City objects
        List<Location> locations = JsonSerializer.Deserialize<List<Location>>(jsonContent!);

        return locations;
    }
}