import React from 'react';
import ReactDOM from 'react-dom/client';
import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";

import {
    IS_PROD_ENVIRONMENT,
    ROUTES
} from "./shared/constants.ts";

import 'bootstrap/dist/css/bootstrap.css';
import './main.css';

import "./shared/i18n/i18n-config";

import { disableReactDevTools } from "@fvilers/disable-react-devtools";
import reportWebVitals from './shared/layout/reportWebVitals.ts';

import {
    QueryClient,
    QueryClientProvider
} from "@tanstack/react-query";

// Functional Components
import App from './App.tsx';
import Predictions from './components/predictions/Predictions.tsx';
import Schedule from './components/schedule/Schedule.tsx';


// Disable React Dev Tools on prod
if (IS_PROD_ENVIRONMENT) {
    disableReactDevTools();
}

const {
    PREDICTIONS,
    SCHEDULE,
    SCORES,
    CONTACT,
    CULTURE,
    RULES
} = ROUTES

const router = createBrowserRouter([
    {
        path: "/*",
        element: <App />,
        children: []
    },
    {
        path: PREDICTIONS,
        element: <Predictions />
    }, {
        path: SCHEDULE,
        element: <Schedule />
    }, {
        path: SCORES,
        element: <Schedule />
    }, {
        path: CONTACT,
        element: <Schedule />
    }, {
        path: CULTURE,
        element: <Schedule />
    }, {
        path: RULES,
        element: <Schedule />
    }
]);

// Create a client
const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <QueryClientProvider client={queryClient}>
            <RouterProvider router={router} />
        </QueryClientProvider>
    </React.StrictMode>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
if (!IS_PROD_ENVIRONMENT)
    reportWebVitals(console.log);
