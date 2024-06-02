const fetchData = async <T,>(url: string): Promise<T> => {
    try {
        const response = await fetch(url);
        const data = await response.json();
        return data;
    } catch (err) {
        console.log(err);
        throw err;
    }
};
  
export default fetchData;