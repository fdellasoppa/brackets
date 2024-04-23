// ENV
export const IS_DEV_ENVIRONMENT = process.env.DEV;
export const IS_PROD_ENVIRONMENT = process.env.PROD;


// Languages
export const ENGLISH_POSITION = 0;
export const SPANISH_POSITION = 1;

export const languages = [
    {
        code: "en-US",
        name: "English",
        locateDate: `en-US`,
        isoCode: "en"
    },
    {
        code: "es-ES",
        name: "Español",
        locateDate: `es-ES`,
        isoCode: "es"
    }
]

export const initialLanguage = languages[ENGLISH_POSITION].code

