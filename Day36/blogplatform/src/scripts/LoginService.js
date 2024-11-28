import axios from 'axios';

export function  login(username,password){
    return axios.post('https://localhost:7078/api/User/UserLogin',{
        "username": username,
        "password": password

    });
}