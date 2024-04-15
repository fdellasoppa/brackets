import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';

import { IS_PROD_ENVIRONMENT } from "./shared/constants.ts";
import { disableReactDevTools } from "@fvilers/disable-react-devtools";

import './index.css';
import "./shared/i18n/i18n-config";

import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";
import reportWebVitals from './shared/layout/reportWebVitals.ts';

// Disable React Dev Tools on prod
if (IS_PROD_ENVIRONMENT) {
    disableReactDevTools();
}

const router = createBrowserRouter([
    {
        path: "/",
        element: <App />,
    },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={router} />
        {/*<App />*/}
    </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
if (!IS_PROD_ENVIRONMENT)
    reportWebVitals(console.log);
