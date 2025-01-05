import React from 'react';
import { Input, InputGroup } from 'reactstrap';

function SearchBar({ searchTerm, setSearchTerm }) {
  const handleSearch = (e) => {
    setSearchTerm(e.target.value);
  };

  return (
    <div className="mb-4">
      <InputGroup>
        <Input
          type="text"
          placeholder="Kurs ara..."
          value={searchTerm}
          onChange={handleSearch}
          style={{ borderRadius: '20px' }}
        />
      </InputGroup>
    </div>
  );
}

export default SearchBar;
