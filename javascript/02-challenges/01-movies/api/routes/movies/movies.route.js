import express from "express";

const router = express.Router();

const DbName = "movies";

/**
 * getPagination is a function that calculates and returns the size and page for pagination.
 * It ensures that the size does not exceed 15 and the page is not less than 1.
 * If size or page are not provided, or if they are null or undefined, default values are used.
 *
 * @param {number} [size=5] - The number of items per page. If not provided, defaults to 5.
 * @param {number} [page=1] - The current page number. If not provided, defaults to 1.
 *
 * @returns {Object} An object containing the size and page for pagination.
 * @returns {number} .size - The number of items per page, with a maximum of 15.
 * @returns {number} .page - The current page number, with a minimum of 1.
 */
const getPagination = (size = 5, page = 1) => {
    size = Math.min(20, +size);
    page = Math.max(1, +page);
    return {size, page};
};

/**
 * paginate is a function that divides the data into pages.
 * It calculates the start and end indexes for the current page and returns a new array with only the items on that page.
 *
 * @param {Array} data - The data to be paginated.
 * @param {number} size - The number of items per page.
 * @param {number} page - The current page number.
 *
 * @returns {Array} An array containing the items on the current page.
 */
const paginate = (data, size, page) => {
    // calculate start and end item indexes
    const startIndex = (page - 1) * size;
    const endIndex = page * size;

    // create a new array with only the items on the current page
    return data.slice(startIndex, endIndex);
};

/**
 * getPagingData is a function that calculates and returns the pagination data.
 * It calculates the total number of items, the total number of pages, and the current page.
 * It also returns the items for the current page.
 *
 * @param {Object} data - The data to be paginated. It should have a count property representing the total number of items and a rows property representing the items.
 * @param {number} page - The current page number.
 * @param {number} limit - The number of items per page.
 *
 * @returns {Object} An object containing the pagination data.
 * @returns {number} .totalItems - The total number of items.
 * @returns {Array} .movies - The items for the current page.
 * @returns {number} .totalPages - The total number of pages.
 * @returns {number} .currentPage - The current page number.
 */
const getPagingData = (data, page, limit) => {
    const {count: totalItems, rows: movies} = data;
    const currentPage = page ? +page : 0;
    const totalPages = Math.ceil(totalItems / limit);

    return {totalItems, data: movies, totalPages, currentPage};
};

/**
 * @swagger
 * components:
 *   schemas:
 *     Movie:
 *       type: object
 *       properties:
 *         backdropPath:
 *           type: string
 *           description: The backdrop path of the movie.
 *         id:
 *           type: integer
 *           description: The ID of the movie.
 *         originalLanguage:
 *           type: string
 *           description: The original language of the movie.
 *         originalTitle:
 *           type: string
 *           description: The original title of the movie.
 *         overview:
 *           type: string
 *           description: The overview of the movie.
 *         popularity:
 *           type: number
 *           format: float
 *           description: The popularity of the movie.
 *         posterPath:
 *           type: string
 *           description: The poster path of the movie.
 *         releaseDate:
 *           type: string
 *           format: date
 *           description: The release date of the movie.
 *         title:
 *           type: string
 *           description: The title of the movie.
 *         voteAverage:
 *           type: number
 *           format: float
 *           description: The average vote of the movie.
 *         voteCount:
 *           type: integer
 *           description: The vote count of the movie.
 *       required:
 *         - id
 *         - title
 *       example:
 *          id: 1011985,
 *          originalLanguage: en,
 *          originalTitle: Kung Fu Panda 4,
 *          overview: Shifu annonce à Po qu'il doit devenir le nouveau Chef Spirituel, et ainsi laisser sa place à un autre Dragon Guerrier.,
 *          popularity: 4795.12,
 *          posterPath: /kDp1vUBnMpe8ak4rjgl3cLELqjU.jpg,
 *          releaseDate: 2024-03-02,
 *          title: Kung Fu Panda 4,
 *          voteAverage: 7.011,
 *          voteCount: 321
 */


/**
 * @swagger
 * tags:
 *   name: Movies
 *   description: The movies managing API
 */

/**
 * @swagger
 * /api/movies:
 *   get:
 *     summary: Returns the list of all the movies
 *     tags: [Movies]
 *     parameters:
 *       - in: query
 *         name: page
 *         schema:
 *           type: integer
 *         description: The page number for pagination.
 *       - in: query
 *         name: size
 *         schema:
 *           type: integer
 *         description: The number of items per page for pagination.
 *     responses:
 *       200:
 *         description: The list of the movies
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                  totalItems:
 *                     type: integer
 *                     description: The total number of movies.
 *                  totalPages:
 *                      type: integer
 *                      description: The total number of pages.
 *                  currentPage:
 *                      type: integer
 *                      description: The current page number.
 *                  data:
 *                      type: array
 *                      items:
 *                        $ref: '#/components/schemas/Movie'
 *       400:
 *          description: Error retrieving movies
 */
router.get("/", (req, res) => {
    try {
        const {size, page} = getPagination(req.query.size, req.query.page);

        const movies = req.app.db.data[DbName];

        // Filter data by page and size
        const paginatedData = paginate(movies, size, page);

        const response = getPagingData({count: movies.length, rows: paginatedData}, page, size);

        res.send(response);
    } catch (error) {
        console.log(error);

        return res.status(400).send({
            message: "Error retrieving movies"
        });
    }
});

/**
 * @swagger
 * /api/movies/{id}:
 *   get:
 *     summary: Get the movie by id
 *     tags: [Movies]
 *     parameters:
 *       - in: path
 *         name: id
 *         schema:
 *           type: string
 *         required: true
 *         description: The movie id
 *     responses:
 *       200:
 *         description: The movie by id
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/Movie'
 *       404:
 *         description: The movie was not found
 *       400:
 *        description: Error retrieving movie
 */
router.get("/:id", (req, res) => {
    try {
        const id = req.params.id;

        const movie = req.app.db.data[DbName].find((x) => x.id === id);

        if (!movie) {
            res.sendStatus(404)
        }

        res.send(movie);
    } catch (error) {
        console.log(error);

        return res.status(400).send({
            message: "Error retrieving Movie."
        });
    }

});

export default router;