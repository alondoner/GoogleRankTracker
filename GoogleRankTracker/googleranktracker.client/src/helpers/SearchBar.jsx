import ReactDOM from 'react-dom/client';
import React, { useState } from 'react';

const SearchBar = () => {
    const [inputs, setInputs] = useState([]);
    const [newSearch, setNewSearch] = useState([]);
    const [retrieved, setRetrieved] = useState(false);

    const handleChange = (event) => {
        const name = event.target.name;
        const value = event.target.value;
        setInputs(values => ({ ...values, [name]: value }))
    }
    
    async function getNewSearch(keywords, url) {
        try {
            const res = await fetch('https://localhost:7013/googlesearch/' + keywords + '/' + url, { method: 'POST' });
            const data = await res.json();
            setNewSearch(data);
        }
        catch (err) { console.log(err.message); }
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        setRetrieved(false);
        getNewSearch(inputs.keywords, inputs.url).then(() => {
            setRetrieved(true);
        });
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <label>Enter your keyword(s):
                    <input
                        type="text"
                        name="keywords"
                        placeholder="e.g. land registry london"
                        value={inputs.keywords || ""}
                        required="required" 
                        onChange={handleChange}
                    />
                </label>
                <label>Enter your URL:
                    <input
                        type="text"
                        name="url"
                        placeholder="e.g. www.infotrack.co.uk"
                        value={inputs.url || ""}
                        required="required" 
                        onChange={handleChange}
                    />
                </label>
                <button>Get Ranking(s)</button>
            </form>
            <div id="result" style={{ visibility: retrieved ? "visible" : "hidden" }}>
                <label>
                    {newSearch.rankings == "0" ? "Nothing shows up in the ranking of the 100 first results" : "Used '" + newSearch.keywords + "' as keyword(s) your URL '" + newSearch.url + "' appears in the following ranking(s): '" + newSearch.rankings + "' on 'www.google.co.uk' search page"}
                </label>
            </div>
        </>
    )
}

export default SearchBar;