using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Game.Core;
using UnityEngine;


public static class SavingSystem
{
   public static void SaveGame(Core core)
   {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream stream = new FileStream(GetSavingPath(), FileMode.Create);

        PlayerData playerData = new PlayerData(core);
        binaryFormatter.Serialize(stream, playerData);
        stream.Close();
   } 

   public static PlayerData LoadGame()
   {
        if(File.Exists(GetSavingPath()))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();          
            FileStream stream = new FileStream(GetSavingPath(), FileMode.Open);
            PlayerData playerData = binaryFormatter.Deserialize(stream) as PlayerData;
                               
            stream.Close();          
            return playerData;
        }
        else
        {
            Debug.LogError("There is no file at:" + GetSavingPath());
            return null;
        }
   }

   private static string GetSavingPath()
   {
       return Path.Combine(Application.persistentDataPath + "save.saving");
   }
}
