import Api from '../Http/Api'
import Persistance from './AuthPersistance'

export default {

    Login: async (username, password) => {
        try{
            var response = await Api.post("/api/Account/Login", { UserName: username, Password: password });

            if (response.token !== undefined) {
                var authData = {
                    token: response.token,
                    isAuthenticated: true
                };

                Persistance.set("_+", JSON.stringify(authData));

                return true;
            }
            else{
                return false;
            }
        }
        catch{
            return false;
        }
    },

    Register: async (username, password, email) => {
        try{
            var response = await Api.post("/api/Account/Register", { Email: email, UserName: username, Password: password });

            if (response.token !== undefined) {
                var authData = {
                    token: response.token,
                    isAuthenticated: true
                };

                Persistance.set("_+", JSON.stringify(authData));

                return true;
            }
            else{
                return response;
            }
        }
        catch (exception){
            return exception;
        }
    },

    GetUser: async () => {
        try {
            return await Api.get(`/api/Account`);
        }
        catch {
            return null;
        }
    },

    Logout: () => {
        Persistance.remove("_+");
    },

    IsLoggedIn: () => {
        try {
            var authData = JSON.parse(Persistance.get("_+"));

            return authData.isAuthenticated ?? false;
        }
        catch
        {
            return false;
        }
    }

}