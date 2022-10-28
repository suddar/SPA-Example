import axios from 'axios';

export default class CommandService {
    baseUrl = "https://localhost:5001/api";

    async send(command) {
        try {
            let token = sessionStorage.getItem("token");
            let authorization = {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            };
            let response = await axios.post(this.baseUrl, command, authorization);
            return response.data
        } catch (error) {
            return undefined;
        }
    }
}


