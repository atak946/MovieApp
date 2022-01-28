import Api from '../Http/Api'

export default {

    Get: async (id) => {
        if (id === undefined || id <= 0) return null;

        try {
            return await Api.get(`/api/Movie?id=${id}`);
        }
        catch {
            return null;
        }
    },

    GetList: async (page, limit, type) => {
        if (page === undefined || page <= 0) page = 1;
        if (limit === undefined || limit <= 0) limit = 10;
        if (type === undefined || type <= 0) type = 1;

        try {
            return await Api.get(`/api/Movie/GetAll?page=${page}&limit=${limit}&type=${type}`);
        }
        catch(exception) {
            return exception.message;
        }
    },
}