import axios from "axios";
import secureStorage from "../Auth/AuthPersistance";

const HttpContext = axios.create({
    baseURL: "http://localhost:5001",
    headers: {
    },
});

function GetToken(){
    const serializedState = secureStorage.get('_+')
    if (serializedState == null || serializedState == "") return "";
    var _store = JSON.parse(serializedState);
    
    return _store.token;
}

HttpContext.interceptors.request.use(
    function (config) {
        var token = GetToken();

        if (token) config.headers.Authorization = `Bearer ${token}`;
        
        return config;
    },
    function (error) {
        return Promise.reject(error);
    }
);


HttpContext.interceptors.response.use(
    res => res,
    (error) => {
        if (String(error).indexOf("failed with status code 401") > 0){
            window.location.href = "/login";
        }
        else
            return error;
    }
);

export default HttpContext;