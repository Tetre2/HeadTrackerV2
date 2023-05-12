using System;
using System.Text.Json;

public class UserPersistence
{

    private static readonly Lazy<UserPersistence> lazy = new Lazy<UserPersistence>(() => new UserPersistence());
    public static UserPersistence Instance { get { return lazy.Value; } }
    private String appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HeadTracker");
    private String profileFile = "Profiles.json";
    public static float PROFILE_VERSION = 0.02f;
    private bool profilesChanged = false; //used to not have to write the profiles if nothing has changed since last load
    public List<Profile> Profiles { get; set; }
    public class Profile
    {
        public string name { get; set; }

        public string id { get; set; }

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

        public override string ToString()
        {
            return name;
        }
    }

    private static Profile defaultprofile = new Profile
    {
        name = "default Profile",
        id = Guid.NewGuid().ToString(),
        sensitivityPitch = 7000,
        sensitivityYaw = 5000,
        sensitivityRoll = 10,
        commonSensitivity = 1,
        useIndividualSensitivity = true,

        exponentialPitch = 30,
        exponentialYaw = 30,
        exponentialRoll = 10,
        commonExponential = 1,
        useIndividualExponential = false,

        offsetPitch = -2.6f,
        offsetYaw = 1.49f,
        offsetRoll = -0.82f,

        viewLimitPitch = 80,
        viewLimitYaw = 80,
        viewLimitRoll = 80,

        enableGyro = true,
        useExponential = true,
        useSmoothness = true,

        hotkey = Keys.F1,
        COMPort = "COM5"
    };

    private class JsonObj
    {
        public float version { get; set; }
        public List<Profile> profiles { get; set; }
    }

    private UserPersistence()
    {

        Profiles = loadProfiles();

    }

    public void createNewProfile()
    {
        profilesChanged = true;

        //TODO
    }

    public void ModifyProfile()
    {
        profilesChanged = true;

        //TODO
    }

    public void RemoveProfile()
    {
        profilesChanged = true;

        //TODO
    }

    public void Close()
    {
        writeProfiles();
    }

    private void writeProfiles()
    {
        if (profilesChanged)
        {
            writeProfilesToFile(new JsonObj { version = 0.01f, profiles = Profiles });
        }
    }

    //returns the profiles in the json file
    private List<Profile> loadProfiles()
    {
        Directory.CreateDirectory(appDataPath);

        if (Directory.GetFiles(appDataPath).Length > 0)
        {

            string jsonString = File.ReadAllText(Path.Combine(appDataPath, profileFile));
            JsonObj? jsonProfiles = JsonSerializer.Deserialize<JsonObj>(jsonString);
            if (jsonProfiles != null && jsonProfiles.version == PROFILE_VERSION)
            {
                return jsonProfiles.profiles;
            }

        }
        MessageBox.Show("Error loading User Profiles!\nCreating a Default Profile", "Error loading User Profiles",
            MessageBoxButtons.OK, MessageBoxIcon.Error);

        //Overwrite the current file if deserialization faild or is wrong version or if there does not exist a file from the begining
        writeProfilesToFile(new JsonObj { version = 0.01f, profiles = (new List<Profile> { defaultprofile }) });
        return new List<Profile> { defaultprofile };

    }

    private void writeProfilesToFile(JsonObj obj)
    {
        using FileStream createStream = File.Create(Path.Combine(appDataPath, profileFile));
        var options = new JsonSerializerOptions { WriteIndented = true };
        JsonSerializer.Serialize(createStream, obj, options);
        createStream.Close();
    }

}
