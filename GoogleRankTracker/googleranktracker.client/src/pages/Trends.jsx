import React, { useState } from 'react';

const Trends = () => {
    const [trends, setTrends] = useState([]);    

    async function getTrends() {
        try {
            const res = await fetch('https://localhost:7013/googlesearch/trends', { method: 'GET' });
            const data = await res.json();
            setTrends(data);
        }
        catch (err) { console.log(err.message); }
    }

    getTrends();

    return (
        <>
            <h1>Trends</h1>
            <table>
                <tr>
                    <th>Number</th>
                    <th>Url</th>
                    <th>Keyword(s)</th>
                </tr>
                {trends.map((trend, index) => (
                    <tr>
                        <td>{index + 1}</td>
                        <td>{trend.url}</td>
                        <td>{trend.keywords}</td>
                    </tr>
                ))}
            </table>
        </>
    );
};

export default Trends;