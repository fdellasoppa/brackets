/// <reference types="vite/client" />

interface ImportMetaEnv {
    //readonly VITE_APP_TITLE: string,
    // more env variables...
    readonly VITE_REACT_APP_BASE_API_URL: string,
    readonly REACT_APP_BASE_API_URL: string,
}

interface ImportMeta {
    readonly env: ImportMetaEnv
}