import environment from "../../environment";

// ENV
export const IS_DEV_ENVIRONMENT = ["local", "dev"].some(
    (element) => element === environment
)
export const IS_BROADCAST = process.env.REACT_APP_IS_BROADCAST === "true"
export const IS_PROD_ENVIRONMENT = environment === "prod"
