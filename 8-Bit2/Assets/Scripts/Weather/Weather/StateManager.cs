using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
	public WeatherData weatherData;
	public string currentWeather;
	/*
	private bool rain;
	private bool snow;
	private bool cloudy;
	private bool partlyCloudy;
	private bool sunny;
	*/
	public GameObject rainForeObject;
	public GameObject rainBackObject;
	public GameObject rainSkyObject;
	public GameObject rainCloudObject;
	public GameObject snowObject;
	public GameObject snowSkyObject;
	public GameObject snowCloudObject;
	public GameObject cloudyObject;
	public GameObject cloudySkyObject;
	public GameObject cloudyCloudObject;
	public GameObject sunnyObject;
	public GameObject sunnySkyObject;
	public GameObject theSun;
	public GameObject bloom;

	void Update () {
		currentWeather = weatherData.Info.currently.icon;
		//currentWeather = "partly-cloudy-day"; //FOR TESTING!!

		if (currentWeather == "rain") {
			SpawnRain ();
		} else if (currentWeather == "snow" || currentWeather == "sleet") {
			SpawnSnow ();
		} else if (currentWeather == "cloudy" || currentWeather == "fog") {
			SpawnCloudy ();
		} else if (currentWeather == "partly-cloudy-day" || currentWeather == "partly-cloudy-night") {
			SpawnPartlycloudy ();
		} else if (currentWeather == "clear-day" || currentWeather == "clear-night" || currentWeather == "wind") {
			SpawnSunny ();
		} else {
			None ();
		}
	}

	void SpawnRain () {
		//rain = true;
		sunnyObject.SetActive (false);
		sunnySkyObject.SetActive (false);
		rainForeObject.SetActive (true);
		rainBackObject.SetActive (true);
		rainSkyObject.SetActive (true);
		rainCloudObject.SetActive (true);
		/*
		if (snow) {
			StartCoroutine (DisableSnow());
		} else if (cloudy) {
			StartCoroutine (DisableCloudy());
		} else if (partlyCloudy) {
			StartCoroutine (DisablePartlycloudy());
		} else if (sunny) {
			StartCoroutine (DisableSunny());
		}
		*/
	}
	void SpawnSnow () {
		//snow = true;
		sunnyObject.SetActive (false);
		sunnySkyObject.SetActive (false);
		snowObject.SetActive (true);
		snowSkyObject.SetActive (true);
		snowCloudObject.SetActive (true);
		/*
		if (rain) {
			StartCoroutine (DisableRain());
		} else if (cloudy) {
			StartCoroutine (DisableCloudy());
		}  else if (partlyCloudy) {
			StartCoroutine (DisablePartlycloudy());
		} else if (sunny) {
			StartCoroutine (DisableSunny());
		}*/
	} void SpawnCloudy () {
		//cloudy = true;
		sunnyObject.SetActive (false);
		sunnySkyObject.SetActive (false);
		//cloudyObject.SetActive (true);
		cloudySkyObject.SetActive (true);
		cloudyCloudObject.SetActive (true);
		/*if (snow) {
			StartCoroutine (DisableSnow());
		} else if (rain) {
			StartCoroutine (DisableRain());
		} else if (sunny) {
			StartCoroutine (DisableSunny());
		} else if (partlyCloudy) {
			StartCoroutine (DisablePartlycloudy());
		}*/
	} void SpawnPartlycloudy () {
		//partlyCloudy = true;
		cloudyObject.SetActive (true);
		sunnyObject.SetActive (true);
		sunnySkyObject.SetActive (true);
		theSun.SetActive (true);
		theSun.GetComponent<SunMovement>().moveSun = true;
		bloom.SetActive (true);

		/*if (snow) {
			StartCoroutine (DisableSnow());
		} else if (rain) {
			StartCoroutine (DisableRain());
		} else if (sunny) {
			StartCoroutine (DisableSunny());
		}*/
	}
	void SpawnSunny () {
		//sunny = true;
		sunnyObject.SetActive (true);
		sunnySkyObject.SetActive (true);
		theSun.SetActive (true);
		theSun.GetComponent<SunMovement>().moveSun = true;
		bloom.SetActive (true);
		//theSun.moveSun = true;
		/*if (snow) {
			StartCoroutine (DisableSnow());
		} else if (cloudy) {
			StartCoroutine (DisableCloudy());
		}  else if (partlyCloudy) {
			StartCoroutine (DisablePartlycloudy());
		} else if (rain) {
			StartCoroutine (DisableRain());
		}*/
	}

	void None () {
		sunnyObject.SetActive (true);
		sunnySkyObject.SetActive (true);
	}
}

	/* DISABLERS ONLY REQUIRED IF THE FUNCTION IS BEING CONSTANTLY UPDATED


	void None () {
		if (rain) {
			StartCoroutine (DisableRain());
		} else if (cloudy) {
			StartCoroutine (DisableCloudy());
		} else if (partlyCloudy) {
			StartCoroutine (DisablePartlycloudy());
		} else if (sunny) {
			StartCoroutine (DisableSunny());
		} else if (snow) {
			StartCoroutine (DisableSnow());
		}
	}

	IEnumerator DisableRain() {
		rain = false;
		rainForeObject.GetComponent<ParticleSystem> ().Stop();
		yield return new WaitForSeconds(5);
		rainForeObject.SetActive (false);
	}

	IEnumerator DisableSnow() {
		snow = false;
		snowObject.GetComponent<ParticleSystem> ().Stop();
		yield return new WaitForSeconds(5);
		snowObject.SetActive (false);
	}

	IEnumerator DisableCloudy() {
		cloudy = false;
		yield return new WaitForSeconds(5);
		cloudyObject.SetActive (false);
	}

	IEnumerator DisablePartlycloudy() {
		cloudy = false;
		yield return new WaitForSeconds(5);
		cloudyObject.SetActive (false);
	}

	IEnumerator DisableSunny() {
		sunny = false;
		yield return new WaitForSeconds(5);
		sunnyObject.SetActive (false);
	}
}*/