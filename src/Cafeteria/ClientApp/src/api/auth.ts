import axios from "../axios"
import { User } from "../store/Login"

export const authenticate = (username: string, password: string) => {
    const credentials = {
        username,
        password,
    }
    return axios
        .post<User>(`/api/Users/authenticate`, credentials);
}

export const getUserDataByUserId = (id: number) =>
    axios.get(`/api/Users/${id}`)


export const registration = (username: string, password: string) => {
    const credentials = {
        username,
        password,
    }
    return axios
        .post(`/api/Users/registration`, credentials)
        .then(response => response)
        .catch(error => error)
}
