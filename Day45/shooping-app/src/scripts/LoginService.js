import axios from 'axios';



export function login(username, password) {
  return axios.post('http://localhost:5230/api/User/Login', {
    "username": username,
    "password": password
  });
}