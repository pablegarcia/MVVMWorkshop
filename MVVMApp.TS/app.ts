import * as http from 'http';
import fetch from 'node-fetch';

type Employee = {
    name: string;
    lastName: string;
    email: string;
    rol: string;
    location: string;
};

const port = process.env.port || 1337;
const API_URL = 'http://localhost:5041/api/employee'; 

const server = http.createServer(async (req, res) => {
    if (req.url === '/' && req.method === 'GET') {
        try {
            const response = await fetch(API_URL);
            let data: Employee[] = await response.json() as Employee[];

            console.log('Employees:', data); 

            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.end(
                data.map((e: any) => `${e.name} ${e.lastName} (${e.email})`).join('\n')
            );
        } catch (err) {
            console.error('Error fetching employees:', err);
            res.writeHead(500, { 'Content-Type': 'text/plain' });
            res.end('Failed to fetch employees.');
        }
    } else {
        res.writeHead(404);
        res.end();
    }
});

server.listen(port, () => {
    console.log(`Server listening on http://localhost:${port}`);
});