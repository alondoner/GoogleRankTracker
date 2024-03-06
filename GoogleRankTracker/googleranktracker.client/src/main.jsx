import React from 'react'
import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './pages/Layout.jsx';
import Search from './pages/Search.jsx';
import History from './pages/History.jsx';
import Trends from './pages/Trends.jsx';
import NotFound from './pages/NotFound.jsx';
import './index.css'

ReactDOM.createRoot(document.getElementById('root')).render(
    <BrowserRouter>
        <Routes>
            <Route path="/" element={<Layout />}>
                <Route index element={<Search />} />
                <Route path="search" element={<Search />} />
                <Route path="history" element={<History />} />
                <Route path="trends" element={<Trends />} />
                <Route path="*" element={<NotFound />} />
            </Route>
        </Routes>
    </BrowserRouter>,
)