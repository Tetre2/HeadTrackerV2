using System;
using System.Text.Json;
using HeadTrackerV2;
using HeadTrackerV2.Utils;

public class UserPersistence
{

    private static readonly Lazy<UserPersistence> lazy = new Lazy<UserPersistence>(() => new UserPersistence());
    public static UserPersistence Instance { get { return lazy.Value; } }
    private String appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HeadTracker");
    private String profileFile = "Profiles.json";
    private int currentProfileId = 0;

    public static float PROFILE_VERSION = 0.03f;
    private List<UserProfile> Profiles = new List<UserProfile>();
    
    public List<int> GetAllProfileIds()
    {
        List<int> profileIds = new List<int>();
        foreach (UserProfile p in Profiles)
        {
            profileIds.Add(p.id);
        }
        return profileIds;
    }

    public UserProfile GetProfile(int id)
    {
        foreach (UserProfile p in Profiles)
        {
            if (p.id == id)
            {
                return p;
            }
        }
        return null;
    }

    public UserProfile GetCurrentUserProfile()
    {
        return GetProfile(currentProfileId);
    }

    public void RemoveProfile(int id)
    {

    }

    public void AddProfile(UserProfile profile)
    {

    }

    public void ModifyProfile(int id, UserProfile profile)
    {

    }

    private static int getCurrentMaxId()
    {
        //TODO loop all profiles and get max id
        return 0;
    }

    private static UserProfile defaultprofile = new UserProfile
    {
        name = "Default Profile",
        id = 0,
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

    public UserProfile EmptyProfile = new UserProfile
    {
        name = "New Profile",
        id = getCurrentMaxId() + 1,
        sensitivityPitch = 0,
        sensitivityYaw = 10,
        sensitivityRoll = 0,
        commonSensitivity = 0,
        useIndividualSensitivity = false,

        exponentialPitch = 0,
        exponentialYaw = 0,
        exponentialRoll = 0,
        commonExponential = 0,
        useIndividualExponential = false,

        offsetPitch = 0,
        offsetYaw = 0,
        offsetRoll = 0,

        viewLimitPitch = 0,
        viewLimitYaw = 0,
        viewLimitRoll = 0,

        enableGyro = false,
        useExponential = false,
        useSmoothness = false,

        hotkey = Keys.F1,
        COMPort = "COM5"
    };

    private class JsonObj
    {
        public float version { get; set; }
        public int currentProfile { get; set; }
        public List<UserProfile> profiles { get; set; }
    }

    private UserPersistence()
    {
        Profiles = loadProfiles();
        Form1.ProfilePopup.ProfileSelected += ProfilePopup_ProfileSelected;
    }

    private void ProfilePopup_ProfileSelected(object? sender, EventArgs e)
    {
        //TODO set active profile
        currentProfileId = (e as ProfileArgs).profile.id;
        Console.WriteLine("UserPersistence: recived Event! {0}", currentProfileId);
    }

    public void Close()
    {
        writeProfiles();
    }

    private void writeProfiles()
    {
        writeProfilesToFile(new JsonObj { version = 0.01f, currentProfile = currentProfileId, profiles = Profiles });
    }

    //returns the profiles in the json file
    private List<UserProfile> loadProfiles()
    {
        Directory.CreateDirectory(appDataPath);

        if (Directory.GetFiles(appDataPath).Length > 0)
        {

            string jsonString = File.ReadAllText(Path.Combine(appDataPath, profileFile));
            try
            {
                JsonObj? jsonProfiles = JsonSerializer.Deserialize<JsonObj>(jsonString);
                if (jsonProfiles != null && jsonProfiles.version == PROFILE_VERSION)
                {
                    return jsonProfiles.profiles;
                }
            }
            catch (Exception)
            {
                
            }
            MessageBox.Show("Error loading User Profiles!\nCreating a Default Profile", "Error loading User Profiles",
     MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
 

        //Overwrite the current file if deserialization faild or is wrong version or if there does not exist a file from the begining
        writeProfilesToFile(new JsonObj { version = 0.01f, profiles = (new List<UserProfile> { defaultprofile }) });
        return new List<UserProfile> { defaultprofile };

    }

    private void writeProfilesToFile(JsonObj obj)
    {
        using FileStream createStream = File.Create(Path.Combine(appDataPath, profileFile));
        var options = new JsonSerializerOptions { WriteIndented = true };
        JsonSerializer.Serialize(createStream, obj, options);
        createStream.Close();
    }

}
