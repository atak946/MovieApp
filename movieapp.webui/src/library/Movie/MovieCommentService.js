import Api from '../Http/Api'

export default {

    Get: async (id) => {
        if (id === undefined || id <= 0) return null;

        try {
            return await Api.get(`/api/Comment?id=${id}`);
        }
        catch {
            return null;
        }
    },

    GetList: async (page, limit, movieId) => {
        if (page === undefined || page <= 0) page = 1;
        if (limit === undefined || limit <= 0) limit = 10;
        if (movieId === undefined || movieId <= 0) return null;

        try {
            return await Api.get(`/api/Comment/GetAll?page=${page}&limit=${limit}&movieId=${movieId}`);
        }
        catch(exception) {
            return exception.message;
        }
    },

    AddComment: async (movieId, comment, rate) => {
        if (movieId === undefined || movieId <= 0) return "Lütfen sayfayı yenileyip tekrar deneyin.";
        if (comment === undefined || String(comment).length < 3) return "3 karakterden daha az yorum yapılamaz.";
        if (rate === undefined || parseFloat(rate) < 0 || parseFloat(rate) > 10) return "Puan aralığınız 0 ile 10 arasında olmalıdır";

        try {
            return await Api.post(`/api/Comment`, {MovieId: movieId, Comment: comment, Rate: rate});
        }
        catch(exception) {
            return exception.message;
        }
    },
}