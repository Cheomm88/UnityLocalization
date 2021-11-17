using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class ChangeLanguage : MonoBehaviour
{
    int index = 0;
    bool init = false;
    // Start is called before the first frame update
    void Init()
    {
        index = 0;
        UnityEngine.Localization.Locale searcher = LocalizationSettings.AvailableLocales.Locales[index];        

        while (LocalizationSettings.SelectedLocale != searcher && index < LocalizationSettings.AvailableLocales.Locales.Count)
        {
            index++;
            searcher = LocalizationSettings.AvailableLocales.Locales[index];
        }

        init = true;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyUp(KeyCode.A)))
        {
            PreviousLanguage();
        }

        if ((Input.GetKeyUp(KeyCode.D)))
        {
            NextLanguage();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            if (init == false)
            {
                Init();

            }

            index++;
            if (index >= LocalizationSettings.AvailableLocales.Locales.Count)
            {
                index = 0;
            }

            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
        }
    }

    public void NextLanguage()
    {
        index++;
        if (index >= LocalizationSettings.AvailableLocales.Locales.Count)
        {
            index = 0;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }

    public void PreviousLanguage()
    {
        index--;
        if (index < 0)
        {
            index = LocalizationSettings.AvailableLocales.Locales.Count-1;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
    }
}
