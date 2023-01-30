using System.Collections.Generic;

[System.Serializable]
public class DataContainer2
{
    public List<Profile> profiles;
    
    public DataContainer2()
    {
        profiles = new List<Profile>();
    }

    public void AddProfile()
    {
        profiles.Add(new Profile());
    }
    public void RemoveProfile(int index)
    {
        profiles.RemoveAt(index);
    }
}
