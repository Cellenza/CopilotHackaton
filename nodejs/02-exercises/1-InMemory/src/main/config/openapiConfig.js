const swaggerJsdoc = require('swagger-jsdoc');
const swaggerUi = require('swagger-ui-express');
const express = require('express');
const app = express();

const devUrl = process.env.REST_OPENAPI_DEV_URL;
const prodUrl = process.env.REST_OPENAPI_PROD_URL;

const options = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'Student API',
      version: '1.0.0',
      description: 'This API exposes endpoints to manage students.',
      contact: {
        name: 'Student Admin',
      },
      license: {
        name: 'MIT License',
        url: 'https://choosealicense.com/licenses/mit/',
      },
    },
    servers: [
      {
        url: devUrl,
        description: 'Server URL in Development environment',
      },
      {
        url: prodUrl,
        description: 'Server URL in Production environment',
      },
    ],
    paths: {
      '/api/students': {
        get: {
          summary: 'Get all students',
          responses: {
            200: {
              description: 'List of students',
              content: {
                'application/json': {
                  schema: {
                    type: 'array',
                    items: {
                      $ref: '#/components/schemas/Student',
                    },
                  },
                },
              },
            },
          },
        },
        post: {
          summary: 'Create a new student',
          requestBody: {
            content: {
              'application/json': {
                schema: {
                  $ref: '#/components/schemas/Student',
                },
              },
            },
          },
          responses: {
            201: {
              description: 'Student created',
              content: {
                'application/json': {
                  schema: {
                    $ref: '#/components/schemas/Student',
                  },
                },
              },
            },
          },
        },
      },
      '/api/students/{id}': {
        get: {
          summary: 'Get a student by ID',
          parameters: [
            {
              name: 'id',
              in: 'path',
              required: true,
              schema: {
                type: 'integer',
              },
            },
          ],
          responses: {
            200: {
              description: 'Student details',
              content: {
                'application/json': {
                  schema: {
                    $ref: '#/components/schemas/Student',
                  },
                },
              },
            },
            404: {
              description: 'Student not found',
            },
          },
        },
        put: {
          summary: 'Update a student by ID',
          parameters: [
            {
              name: 'id',
              in: 'path',
              required: true,
              schema: {
                type: 'integer',
              },
            },
          ],
          requestBody: {
            content: {
              'application/json': {
                schema: {
                  $ref: '#/components/schemas/Student',
                },
              },
            },
          },
          responses: {
            200: {
              description: 'Student updated',
              content: {
                'application/json': {
                  schema: {
                    $ref: '#/components/schemas/Student',
                  },
                },
              },
            },
            404: {
              description: 'Student not found',
            },
          },
        },
        delete: {
          summary: 'Delete a student by ID',
          parameters: [
            {
              name: 'id',
              in: 'path',
              required: true,
              schema: {
                type: 'integer',
              },
            },
          ],
          responses: {
            200: {
              description: 'Student deleted',
            },
            404: {
              description: 'Student not found',
            },
          },
        },
      },
    },
    components: {
      schemas: {
        Student: {
          type: 'object',
          properties: {
            id: {
              type: 'integer',
              example: 1,
            },
            firstName: {
              type: 'string',
              example: 'John',
            },
            lastName: {
              type: 'string',
              example: 'Doe',
            },
          },
        },
      },
    },
  },
  apis: ['./controllers/*.js'], // Path to the API docs
};

const specs = swaggerJsdoc(options);

app.use('/api-docs', swaggerUi.serve, swaggerUi.setup(specs));

module.exports = app;
