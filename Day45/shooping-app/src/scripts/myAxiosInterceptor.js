import axios from "axios";


function requestInterceptor(config) {
    const token = sessionStorage.getItem('token');
    if (token) {
        config.headers['Authorization'] = 'Bearer ' + token;
    }
    return config;
}

// function responseInterceptor(response) {
//     return response;
// }

axios.interceptors.request.use(requestInterceptor);

export default axios;