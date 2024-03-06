import React, { useState } from 'react';

const History = () => {
    const [history, setHistory] = useState([]);

    async function getHistory() {
        try {
            const res = await fetch('https://localhost:7013/googlesearch/history', { method: 'GET' });
            const data = await res.json();
            setHistory(data);
        }
        catch (err) { console.log(err.message); }
    }

    getHistory();        

    return (
        <>
            <h1>History</h1>
            <table>
                <tr>
                    <th>Keyword(s)</th>
                    <th>Url</th>
                    <th>Rankings</th>
                    <th>Date & Time</th>
                </tr>
                {history.map((hist) => (
                    <tr>
                        <td>{hist.keywords}</td>
                        <td>{hist.url}</td>
                        <td>{hist.rankings}</td>
                        <td>{hist.formatteddatetime}</td>
                    </tr>
                ))}
            </table>
        </>
    );
};

export default History;