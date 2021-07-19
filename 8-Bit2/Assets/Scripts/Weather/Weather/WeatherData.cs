using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class WeatherData : MonoBehaviour {
	private float timer;
	//public float minutesBetweenUpdate;
	public WeatherInfo Info;
	public string API_key;
	private float latitude;
	private float longitude;
	//private bool locationInitialized;
	private GetLocation getLocation;

	void Start() {

		getLocation = gameObject.GetComponent<GetLocation>();
		latitude = getLocation.latitude;
		longitude = getLocation.longitude;

		StartCoroutine (GetWeatherInfo ());
		
		/* constant updates to weather

		if (locationInitialized) {
			if (timer <= 0) {
				StartCoroutine (GetWeatherInfo ());
				timer = minutesBetweenUpdate * 60;
			} else {
				timer -= Time.deltaTime;
			}
		}
		*/ 
	}

	private IEnumerator GetWeatherInfo()
	{
		var www = new UnityWebRequest("https://api.darksky.net/forecast/" + API_key + "/" + latitude + "," + longitude)
		{
			downloadHandler = new DownloadHandlerBuffer()
		};

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			//error

			yield break;

		}

		Info = JsonUtility.FromJson<WeatherInfo>(www.downloadHandler.text);
	}
}
[Serializable]
public class WeatherInfo
{
	public float latitude;
	public float longitude;
	public string timezone;
	public Currently currently;
	public int offset;
}

[Serializable]
public class Currently
{
	public int time;
	public string summary;
	public string icon;
	public int nearestStormDistance;
	public int nearestStormBearing;
	public int precipIntensity;
	public int precipProbability;
	public double temperature;
	public double apparentTemperature;
	public double dewPoint;
	public double humidity;
	public double pressure;
	public double windSpeed;
	public double windGust;
	public int windBearing;
	public int cloudCover;
	public int uvIndex;
	public double visibility;
	public double ozone;
}