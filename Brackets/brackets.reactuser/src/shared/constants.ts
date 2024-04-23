// ENV
export const IS_DEV_ENVIRONMENT = import.meta.env.DEV;
export const IS_PROD_ENVIRONMENT = import.meta.env.PROD;


// Languages
export const ENGLISH_POSITION = 0
export const SPANISH_POSITION = 1

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

// Routes
export const ROUTES = {
    PREDICTIONS: "/predictions",
    SCHEDULE: "/schedule",
    SCORES: "/scores",
    CONTACT: "/contact",
    CULTURE: "/culture",
    RULES: "/rules",
    404: "/404"
} as const