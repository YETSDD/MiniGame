using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileManager : MonoBehaviour
{
	public static FileManager instance;

	private string _filePath;

	ModuleSkillMap map;

	private const string _fileNameOfMap = "/playerModuleSkillMap";

	private void Awake()
	{
		instance = this;

		if( Application.platform == RuntimePlatform.WindowsEditor )
		{
			_filePath = Application.streamingAssetsPath + _fileNameOfMap;
		}
		else
		{
			_filePath = Application.persistentDataPath + _fileNameOfMap;
		}
		LoadSerializableFile();
	}

	public void LoadSerializableFile()
	{
		if( File.Exists( _filePath ) )
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open( _filePath, FileMode.Open );
			map = (ModuleSkillMap)bf.Deserialize( file );
			file.Close();
		}
		else
		{
			map = new ModuleSkillMap();
		}
	}

	public void SaveSerializableFile()
	{
		BinaryFormatter bf = new BinaryFormatter();
		if( File.Exists( _filePath ) )
		{
			File.Delete( _filePath );
		}
		FileStream file = File.Create( _filePath );
		bf.Serialize( file, map );
		file.Close();
	}

}
