import axios from 'axios';

export default async function sendCommand(command) {
    try {
        let baseUrl = "https://localhost:6060/api";
        let token = sessionStorage.getItem("token");
        let authorization = {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        };
        let response = await axios.post(baseUrl, command, authorization);
        return response.data;
    } catch (error) {
        return undefined;
    }
}
