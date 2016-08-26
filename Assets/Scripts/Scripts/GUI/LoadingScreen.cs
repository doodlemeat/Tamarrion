using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class LoadingScreen : MonoBehaviour
{
    public float _startGameTimer = 2;
    public string _nextLevel = "Beta";

    public AudioSource menuMusicAudioSource;
    float t = 0.0f;
    float _currentVolume = 0;

    public Text _tip_of_the_day;
    List<string> _tips_of_the_day = new List<string>();
    bool levelLoaded = false;

    public Text pressAnyKeyText;
    public Image progressBar;
    AsyncOperation loadingOperation;
    bool loadingComplete = false;

    void Start()
    {
        if (menuMusicAudioSource)
            _currentVolume = menuMusicAudioSource.volume;

        //tips of the days
        string line;
        if (File.Exists(Application.dataPath + "/tips_of_the_days.txt"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/tips_of_the_days.txt", System.Text.Encoding.UTF8);

            while ((line = sr.ReadLine()) != null)
            {
                _tips_of_the_day.Add(line);
            }

            if (_tips_of_the_day.Count != 0)
            {
                int randomTipIndex = Random.Range(0, _tips_of_the_day.Count - 1);
                _tip_of_the_day.text = _tips_of_the_day[randomTipIndex];
            }
        }
    }

    void Update()
    {
        t += Time.deltaTime;

        if (menuMusicAudioSource && !levelLoaded)
            menuMusicAudioSource.volume = Mathf.Lerp(_currentVolume, 0.0f, t / _startGameTimer);

        _startGameTimer -= Time.deltaTime;
        if (_startGameTimer <= 0 && !levelLoaded)
        {
            levelLoaded = true;
            if (menuMusicAudioSource)
                menuMusicAudioSource.volume = 0f;
            loadingOperation = Application.LoadLevelAsync(_nextLevel);
            loadingOperation.allowSceneActivation = false;
            progressBar.enabled = true;
        }

        if (loadingOperation != null)
        {
            if (!loadingComplete && progressBar)
                progressBar.fillAmount = loadingOperation.progress;

            if (!loadingComplete && loadingOperation.progress >= 0.9f)
            {
                loadingComplete = true;
                progressBar.fillAmount = 1f;
				loadingOperation.allowSceneActivation = true;
                loadingOperation = null;
				pressAnyKeyText.enabled = true;
//                if (pressAnyKeyText)
//                    pressAnyKeyText.enabled = true;
            }

//            if (loadingComplete && (Input.anyKeyDown || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
//            {
//                if (pressAnyKeyText)
//                    pressAnyKeyText.text = "Loading complete, stand by...";
//                loadingOperation.allowSceneActivation = true;
//                loadingOperation = null;
//            }
        }
    }
}
