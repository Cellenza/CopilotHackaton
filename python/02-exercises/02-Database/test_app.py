import pytest
from app import app

@pytest.fixture
def client():
    app.config['TESTING'] = True
    with app.test_client() as client:
        yield client

def test_search_existing_term(client):
    """Test searching for a term that exists in the database."""
    response = client.get('/search/john')
    assert response.status_code == 200
    data = response.get_json()
    assert len(data) > 0  # Assuming 'john' exists in the database

def test_search_non_existing_term(client):
    """Test searching for a term that does not exist in the database."""
    response = client.get('/search/nonexistentterm')
    assert response.status_code == 200
    data = response.get_json()
    assert len(data) == 0  # Assuming 'nonexistentterm' does not exist

def test_search_case_insensitivity(client):
    """Test that the search is case-insensitive."""
    response1 = client.get('/search/John')
    response2 = client.get('/search/john')
    assert response1.status_code == 200
    assert response2.status_code == 200
    data1 = response1.get_json()
    data2 = response2.get_json()
    assert len(data1) == len(data2)  # Assuming case-insensitivity

def test_search_empty_term(client):
    """Test searching for an empty term."""
    response = client.get('/search/')
    assert response.status_code == 200
    data = response.get_json()
    assert len(data) == 0  # Assuming empty term returns no results

def test_search_invalid_term(client):
    """Test searching for an invalid term."""
    response = client.get('/search/123')
    assert response.status_code == 400  # Assuming invalid term returns 400
