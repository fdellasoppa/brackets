import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import { initialLanguage, languages } from "../constants";
// import { Localization } from 'expo-localization';

import en from "./en.json";
import es from "./es.json";

i18n.use(initReactI18next).init({
    returnNull: false,
    returnEmptyString: false,
    fallbackLng: languages.map((language) => language.code),
    interpolation: {
        escapeValue: false
    },
    lng: initialLanguage,
    resources: {
        "en-US": { global: en },
        "es-ES": { global: es }
    }
});

i18n.languages = languages.map((language) => language.code);
// i18n.locale = Localization.locale;

export default i18n;