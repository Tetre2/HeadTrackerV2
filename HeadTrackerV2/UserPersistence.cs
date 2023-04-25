using System;
using System.Text.Json;

public class UserPersistence
{
    private String appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HeadTracker");
    //private String profileFilePath = Path.Combine(appDataPath, "Profiles.json");
    public List<Profile> Profiles { get; set; }
    public class Profile
    {
        public string name { get; set; }

        public float sensitivityPitch { get; set; }
        public float sensitivityYaw { get; set; }
        public float sensitivityRoll { get; set; }
        public float commonSensitivity { get; set; }
        public bool useIndividualSensitivity { get; set; }

        public float exponentialPitch { get; set; }
        public float exponentialYaw { get; set; }
        public float exponentialRoll { get; set; }
        public float commonExponential { get; set; }
        public bool useIndividualExponential { get; set; }

        public float offsetPitch { get; set; }
        public float offsetYaw { get; set; }
        public float offsetRoll { get; set; }

        public float viewLimitPitch { get; set; }
        public float viewLimitYaw { get; set; }
        public float viewLimitRoll { get; set; }

        public bool enableGyro { get; set; }
        public bool useExponential { get; set; }
        public bool useSmoothness { get; set; }

        public Keys? hotkey { get; set; }
        public String? COMPort { get; set; }
    }

    private class JsonObj
    {
        public float version { get; set; }
        //public List<Profile> { get; set; }
}

    public UserPersistence()
	{

        loadProfiles();
        

    }

    private List<Profile> loadProfiles()
    {
        Directory.CreateDirectory(appDataPath);

        if (Directory.GetFiles(appDataPath).Length > 0)
        {
            return null;
        }
        else
        {
            writeDefaultProfileToFile();
            return new List<Profile> { getDefaultProfile() };
        }

    }

    private async Task writeDefaultProfileToFile()
    {
        using FileStream createStream = File.Create(Path.Combine(appDataPath, "Profiles.json"));
        var options = new JsonSerializerOptions { WriteIndented = true };
        await JsonSerializer.SerializeAsync(createStream, new List<Profile> { getDefaultProfile() }, options);
        await createStream.DisposeAsync();
    }

    private Profile getDefaultProfile()
    {
        Profile defaultprofile = new Profile
        {
            name = "default Profile",
            sensitivityPitch = 1,
            sensitivityYaw = 1,
            sensitivityRoll = 1,
            commonSensitivity = 1,
            useIndividualSensitivity = false,

            exponentialPitch = 1,
            exponentialYaw = 1,
            exponentialRoll = 1,
            commonExponential = 1,
            useIndividualExponential = false,

            offsetPitch = 1,
            offsetYaw = 1,
            offsetRoll = 1,

            viewLimitPitch = 1,
            viewLimitYaw = 1,
            viewLimitRoll = 1,

            enableGyro = true,
            useExponential = false,
            useSmoothness = true,

            hotkey = null,
            COMPort = null
        };
        return defaultprofile;
    }
}
