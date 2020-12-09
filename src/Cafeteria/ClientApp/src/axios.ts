import axios, { AxiosRequestConfig } from "axios"
//import { AuthToken } from "./variables/Variables"

//axios.defaults.headers.common[AuthToken.key] = AuthToken.value;

const instance = axios.create({
    headers: {
        Pragma: "no-cache"
    },
});

export const axiosPromise = (configure: AxiosRequestConfig) => instance.request(configure)

export default instance