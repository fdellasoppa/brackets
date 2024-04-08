import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App.tsx';

import { IS_PROD_ENVIRONMENT } from "./utils/constants/constants";
import { disableReactDevTools } from "@fvilers/disable-react-devtools";

import "./i18n/config";
import './index.css';

import {
    createBrowserRouter,
    RouterProvider,
} from "react-router-dom";

// Disable React Dev Tools on prod
if (IS_PROD_ENVIRONMENT) {
    disableReactDevTools()
}

const router = createBrowserRouter([
    {
        path: "/",
        element: <div>Hello world!</div>,
    },
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
    <App />
  </React.StrictMode>,
)
