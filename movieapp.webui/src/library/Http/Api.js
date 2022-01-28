import HttpContext from "./HttpContext";

export default {
    post : (url, data = null) => {
        return new Promise((resolve, reject) => {
            try {
                HttpContext.post(url, data).then((response) => {
                    if (response.status === 200) {
                        resolve(response.data);
                    }
                    else {
                        reject("Beklenmedik bir hata oluştu, " + response.status);
                    }
                }).catch((error) => {
                    reject("Beklenmedik bir hata oluştu, " + error);
                });
            } catch (error) {
                reject("Beklenmedik bir hata oluştu, " + error);
            }
        });
    },
    get: (url) => {
        return new Promise((resolve, reject) => {
            try {
                HttpContext.get(url).then((response) => {
                    if (response.status === 200) {
                        resolve(response.data);
                    }
                    else {
                        reject("Beklenmedik bir hata oluştu, " + response.status);
                    }
                }).catch((error) => {
                    reject("Beklenmedik bir hata oluştu, " + error);
                });
            } catch (error) {
                reject("Beklenmedik bir hata oluştu, " + error);
            }
        });
    }
}